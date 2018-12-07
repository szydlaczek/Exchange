using Autofac;
using Exchange.Infrastructure.UseCases;
using System.Linq;
using System.Reflection;

namespace Exchange.Infrastructure.IOC
{
    public class UseCaseModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(UseCaseModule).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IUseCase>())
                .AsSelf()
                .InstancePerRequest();
            builder.RegisterType<AddCurrenciesUseCase>().AsSelf();
        }
    }
}