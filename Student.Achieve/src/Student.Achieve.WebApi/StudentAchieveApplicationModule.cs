using Fabricdot.Core.Boot;
using Fabricdot.Core.Modularity;
using Fabricdot.Domain.SharedKernel;
using Fabricdot.MultiTenancy.Abstractions;
using Fabricdot.MultiTenancy.AspNetCore;
using Fabricdot.WebApi;
using Fabricdot.WebApi.Tracing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student.Achieve.Infrastructure;
using Student.Achieve.WebApi.Configuration;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi
{
    [Requires(typeof(StudentAchieveInfrastructureModule))]
    [Requires(typeof(FabricdotWebApiModule))]
    [Requires(typeof(FabricdotMultiTenancyAspNetCoreModule))]
    [Exports]
    public class StudentAchieveApplicationModule : ModuleBase
    {
        public override void ConfigureServices(ConfigureServiceContext context)
        {
            var services = context.Services;

            services.AddControllers()
                    .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter()));

            services.AddSwagger();

            SystemClock.Configure(DateTimeKind.Utc);
            services.AddSingleton<IContentTypeProvider, FileExtensionContentTypeProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAuthenticationWithJwt(context.Configuration);
        }

        public override Task OnStartingAsync(ApplicationStartingContext context)
        {
            var services = context.ServiceProvider;
            var app = services.GetApplicationBuilder();
            var env = services.GetRequiredService<IWebHostEnvironment>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorrelationId();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseMultiTenancy();
            app.UseAuthentication();

            app.UseAuthorization();
          
            app.UserSwagger();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            return Task.CompletedTask;
        }
    }
}