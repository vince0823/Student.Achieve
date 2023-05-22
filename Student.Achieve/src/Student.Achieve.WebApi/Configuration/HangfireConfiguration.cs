using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Student.Achieve.WebApi.Configuration
{
    public static class HangfireConfiguration
    {
        public static IServiceCollection ConfigHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            //注册Hangfir配置
            services.AddHangfire(config =>
           {
               config.UseSerilogLogProvider();   //设置使用serilog来记录相关日志 可以更换其他
               config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
               config.UseSimpleAssemblyNameTypeSerializer();
               config.UseRecommendedSerializerSettings();
               //config.UseFilter(new LogHangfireFailureAttribute());  //使用过滤器，当失败重试次数达到最大时记录日志
               //config.UseFilter(new LogHangfirePerformAttribute());  //使用过滤器，当作业执行时触发
               //config.UseMemoryStorage();  //使用本地内存来存储相关数据，也可更换redis和SQL
               config.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"))
           .WithJobExpirationTimeout(TimeSpan.FromDays(1));  //设置使用SQL数据库来存储数据，并且设置过期时间（默认最少为24小时） 必须跟在UseXXXStorage后使用
           });
            // Add the processing server as IHostedService
            services.AddHangfireServer();
            //注册自定义的后台作业
            services.AddTransient<IHangfireJob, HangfireJob>();

            return services;
        }

        public static IApplicationBuilder UseHangfire(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            //判断是否开发环境
            if (environment.IsDevelopment())
            {
                //启用hangfire仪表盘管理功能
                app.UseHangfireDashboard("/hangfire", new DashboardOptions
                {
                    DashboardTitle = "Hangfire Dashboard Manage", //页面标题
                    AppPath = null,
                    //IsReadOnlyFunc = context => true  //设置控制面板仅用于预览
                });
            }
            //var jobId = BackgroundJob.Enqueue(() => Debug.WriteLine("fire-and-forgot job start"));
            //BackgroundJob.ContinueJobWith(jobId, () => Debug.WriteLine("continue job start"));

            //注册后台启动的作业
            using (var scope = app.ApplicationServices.CreateScope())
            {
                #region 各种任务说明
                ////支持基于队列的任务处理：任务执行不是同步的，而是放到一个持久化队列中，以便马上把请求控制权返回给调用者。
                //var jobId = BackgroundJob.Enqueue(() => WriteLog("队列任务执行了！"));

                ////延迟任务执行：不是马上调用方法，而是设定一个未来时间点再来执行，延迟作业仅执行一次
                //var jobId = BackgroundJob.Schedule（() => WriteLog("一天后的延迟任务执行了！"),TimeSpan.FromDays(1));//一天后执行该任务

                ////循环任务执行：一行代码添加重复执行的任务，其内置了常见的时间循环模式，也可基于CRON表达式来设定复杂的模式。【用的比较的多】
                //RecurringJob.AddOrUpdate(() => WriteLog("每分钟执行任务！"), Cron.Minutely); //注意最小单位是分钟

                ////延续性任务执行：类似于.NET中的Task,可以在第一个任务执行完之后紧接着再次执行另外的任务
                //BackgroundJob.ContinueWith(jobId, () => WriteLog("连续任务！"));

                ////不调用方法，仅输出测试
                //RecurringJob.AddOrUpdate("每4时执行一次", () => Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")), "0 0 */4 * * ?", TimeZoneInfo.Local);

                #endregion

                #region corn表达式
                //"30 * * * * ?" 每半分钟触发任务
                //"30 10 * * * ?" 每小时的10分30秒触发任务
                //"30 10 1 * * ?" 每天1点10分30秒触发任务
                //"30 10 1 20 * ?" 每月20号1点10分30秒触发任务
                //"30 10 1 20 10 ? *" 每年10月20号1点10分30秒触发任务
                //"30 10 1 20 10 ? 2011" 2011年10月20号1点10分30秒触发任务
                //"30 10 1 ? 10 * 2011" 2011年10月每天1点10分30秒触发任务
                //"30 10 1 ? 10 SUN 2011" 2011年10月每周日1点10分30秒触发任务
                //"15,30,45 * * * * ?" 每15秒，30秒，45秒时触发任务
                //"15-45 * * * * ?" 15到45秒内，每秒都触发任务
                //"15/5 * * * * ?" 每分钟的每15秒开始触发，每隔5秒触发一次
                //"15-30/5 * * * * ?" 每分钟的15秒到30秒之间开始触发，每隔5秒触发一次
                //"0 0/3 * * * ?" 每小时的第0分0秒开始，每三分钟触发一次
                //"0 15 10 ? * MON-FRI" 星期一到星期五的10点15分0秒触发任务
                //"0 15 10 L * ?" 每个月最后一天的10点15分0秒触发任务
                //"0 15 10 LW * ?" 每个月最后一个工作日的10点15分0秒触发任务
                //"0 15 10 ? * 5L" 每个月最后一个星期四的10点15分0秒触发任务
                //"0 15 10 ? * 5#3" 每个月第三周的星期四的10点15分0秒触发任务
                #endregion

                var hangfireJob = scope.ServiceProvider.GetRequiredService<IHangfireJob>();
                RecurringJob.AddOrUpdate("Run every minute", () => hangfireJob.RunJob(), "* * * * *");
            }
            return app;
        }

    }
}
