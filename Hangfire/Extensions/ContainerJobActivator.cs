using System;

namespace Hangfire.Extensions
{
    public class ContainerJobActivator : JobActivator
    {
        private IServiceProvider Provider { get; set; }

        public ContainerJobActivator(IServiceProvider provider)
        {
            Provider = provider;
        }

        public override object ActivateJob(Type type)
        {
            return Provider.GetService(type);
        }
    }
}
