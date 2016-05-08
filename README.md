# Hangfire.Middleware  

Middleware for [HangfireIO](https://github.com/HangfireIO/Hangfire) to be used with dnx451/net451.  

Can be used like:  
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
  
To use Dependecy injection in classes used by Hangfire, use the custom JobActivator class:
```
GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(serviceProvider));
```
