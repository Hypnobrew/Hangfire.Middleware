using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Extensions
{
    public static class Hangfire
    {
        public static IApplicationBuilder UseHangfireServer([NotNull] this IApplicationBuilder builder)
        {
            return builder.UseHangfireServer(new BackgroundJobServerOptions());
        }

        public static IApplicationBuilder UseHangfireServer(
            [NotNull] this IApplicationBuilder builder,
            [NotNull] BackgroundJobServerOptions options)
        {
            return builder.UseHangfireServer(options, JobStorage.Current);
        }

        public static IApplicationBuilder UseHangfireServer(
            [NotNull] this IApplicationBuilder builder,
            [NotNull] BackgroundJobServerOptions options,
            [NotNull] JobStorage storage)
        {
            
            var server = new BackgroundJobServer(options, storage);
            var lifetime = builder.ApplicationServices.GetRequiredService<IApplicationLifetime>();
            lifetime.ApplicationStopped.Register(server.Dispose);

            return builder;
        }

        public static IApplicationBuilder UseHangfireDashboard([NotNull] this IApplicationBuilder builder)
        {
            return builder.UseHangfireDashboard("/hangfire");
        }
		
        public static IApplicationBuilder UseHangfireDashboard(
            [NotNull] this IApplicationBuilder builder,
            [NotNull] string pathMatch)
        {
            return builder.UseHangfireDashboard(pathMatch, new DashboardOptions());
        }

        public static IApplicationBuilder UseHangfireDashboard(
            [NotNull] this IApplicationBuilder builder,
            [NotNull] string pathMatch,
            [NotNull] DashboardOptions options)
        {
            return builder.UseHangfireDashboard(pathMatch, options, JobStorage.Current);
        }

        public static IApplicationBuilder UseHangfireDashboard(
            [NotNull] this IApplicationBuilder builder,
            [NotNull] string path,
            [NotNull] DashboardOptions options,
            [NotNull] JobStorage storage)
        {

            return builder.Map(path, app =>
            {
                app.UseOwin(next =>
                {
                    next(MiddlewareExtensions.UseHangfireDashboard(options, storage, DashboardRoutes.Routes));
                });
            });
        }
    }
}
