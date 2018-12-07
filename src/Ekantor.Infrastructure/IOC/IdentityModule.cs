using Autofac;
using Exchange.Core.Models;
using Exchange.Infrastructure.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Exchange.Infrastructure.IOC
{
    public class IdentityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserStore>().As<IUserStore<User>>().InstancePerRequest();

            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Ekantor")
            });
            builder.RegisterType<ApplicationUserManager>();

            builder.RegisterType<RoleStore>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}