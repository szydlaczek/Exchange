using Autofac;

namespace Exchange.Infrastructure.IOC
{
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<UseCaseModule>();
            builder.RegisterModule<DbContextModule>();
            builder.RegisterModule<IdentityModule>();

            //builder.RegisterModule<DbValidatorModule>();
            builder.RegisterModule<MediatRModule>();
            builder.RegisterModule<ProviderModule>();
        }
    }
}