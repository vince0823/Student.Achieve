using Fabricdot.Core.Modularity;
using Fabricdot.Domain.DependencyInjection;
using Fabricdot.Identity;
using Fabricdot.Infrastructure;
using Fabricdot.Infrastructure.Data;
using Fabricdot.Infrastructure.EntityFrameworkCore;
using Fabricdot.MultiTenancy.Abstractions;
using Fabricdot.PermissionGranting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Student.Achieve.Domain;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using Student.Achieve.Domain.Aggregates.TenantAggregate;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Infrastructure.Data;
using Student.Achieve.Infrastructure.Data.TypeHandlers;

namespace Student.Achieve.Infrastructure
{
    [Requires(typeof(StudentAchieveDomainModule))]
    [Requires(typeof(FabricdotIdentityModule))]
    [Requires(typeof(FabricdotEntityFrameworkCoreModule))]
    [Requires(typeof(FabricdotPermissionGrantingModule))]
    [Requires(typeof(FabricdotInfrastructureModule))]
    [Exports]
    public class StudentAchieveInfrastructureModule : ModuleBase
    {
        private static readonly ILoggerFactory _dbLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public override void ConfigureServices(ConfigureServiceContext context)
        {
            var services = context.Services;

            #region database

            var connectionString = context.Configuration.GetConnectionString("Default");
            services.AddEfDbContext<AppDbContext>(opts =>
            {
                //TODO:use database provider.   
                opts.UseSqlServer(connectionString);
                opts.UseLoggerFactory(_dbLoggerFactory);
#if DEBUG
                opts.EnableSensitiveDataLogging();
#endif
            });

            SqlMapperTypeHandlerConfiguration.AddTypeHandlers();
            services.AddScoped<ISqlConnectionFactory, DefaultSqlConnectionFactory>(_ => new DefaultSqlConnectionFactory(connectionString));

            #endregion database
            // TODO:Fix package
            
            #region identity

            services.AddIdentity<User, Role>()
                    .AddRepositories<AppDbContext>()
                    .AddDefaultClaimsPrincipalFactory()
                    .AddDefaultTokenProviders();

            #endregion identity

            #region permission-granting

            services.AddPermissionGrantingStore<AppDbContext>();

            #endregion permission-granting
        }
    }
}