using Fabricdot.Core.Boot;
using Fabricdot.Infrastructure.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Student.Achieve.Infrastructure.Data;
using Student.Achieve.WebApi;
using Student.Achieve.WebApi.Application.Validators;
using Student.Achieve.WebApi.Filters;
using System;
using System.IO;

var baseDir = AppDomain.CurrentDomain.BaseDirectory;
var logfile = Path.Combine(baseDir, "logs", "app.log");
Log.Logger = new LoggerConfiguration()
#if DEBUG
    .MinimumLevel.Debug()
#else
    .MinimumLevel.Information()
#endif
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Async(c => c.Console())
    .WriteTo.Async(c => c.File(
        logfile,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Scope} {Message:lj}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: false))
    .CreateLogger();

var logger = Log.Logger;
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
    builder.Services.AddFluentValidationAutoValidation()
                 // .AddFluentValidationClientsideAdapters()
                 .AddValidatorsFromAssemblyContaining(typeof(IFluentValidation));
    builder.Services.Configure<CookiePolicyOptions>(options =>
    {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true; //GDPR规范关闭 如果不关闭可能会cookie写入不了 在本机调试的时候无此问题，发布的时候就会碰到
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });


    builder.Host.UseServiceProviderFactory(new FabricdotServiceProviderFactory())
                .UseSerilog();
    builder.Services.AddBootstrapper<StudentAchieveApplicationModule>();

    var app = builder.Build();
    await app.BootstrapAsync();

    var dbMigrator = app.Services.GetRequiredService<DbMigrator>();
    await dbMigrator.MigrateAsync();

    await app.RunAsync();

    logger.Information("App host starting..");
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "An error occurred when host running.");
}
finally
{
    logger.Information("App host shutting..");
    Log.CloseAndFlush();
}