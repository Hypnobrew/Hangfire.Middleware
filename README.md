# Hangfire.Middleware  

Middleware for [HangfireIO](https://github.com/HangfireIO/Hangfire) to be used with dnx451/net451.  
Licensed under MIT  

```
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
{
    ...
    app.UseHangfireServer();
    app.UseHangfireDashboard("/dashboard");
    RecurringJob.AddOrUpdate<MyService>(x => x.DoAction(), Cron.Minutely());
    ...
}
```
