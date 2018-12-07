using Autofac;
using Exchange.Infrastructure.Context;

namespace Exchange.Infrastructure.IOC
{
    public class DbContextModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerDependency();
        }
    }
}