using Fabricdot.Core.Boot;
using Fabricdot.Infrastructure.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
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