using Autofac;
using System.Linq;

namespace Exchange.Infrastructure.IOC
{
    public class ProviderModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly).Where(t => t.Name.EndsWith("Provider")).AsImplementedInterfaces();
        }
    }
}