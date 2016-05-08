# Hangfire.Middleware  

Middleware for [HangfireIO](https://github.com/HangfireIO/Hangfire) to be used with dnx451/net451.  
Can be used like:

```
app.UseHangfireServer();
RecurringJob.AddOrUpdate<IService>(x => x.DoStuff(), Cron.Minutely());
```

To use Dependecy injection in classes used by Hangfire, use the custom JobActivator class:
```
GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(serviceProvider));
```

