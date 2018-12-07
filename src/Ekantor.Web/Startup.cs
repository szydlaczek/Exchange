using Autofac;
using Autofac.Extras.Quartz;
using Autofac.Integration.Mvc;
using Exchange.Infrastructure.IOC;
using Exchange.Infrastructure.Sheduler;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(Exchange.Web.Startup))]

namespace Exchange.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureContainer(app);
        }

        private void ConfigureContainer(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModelBinderProvider();
            builder.RegisterModule(new ContainerModule());
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            RegisterScheduler(builder);
            var container = builder.Build();
            ConfigureScheduler(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
        private static void ConfigureScheduler(IContainer container)
        {
            var scheduler = container.Resolve<JobScheduler>();
            scheduler.Start();
        }
        private static void RegisterScheduler(ContainerBuilder builder)
        {
            // configure and register Quartz
            var schedulerConfig = new NameValueCollection {
                  {"quartz.threadPool.threadCount", "1"},

                  {"quartz.scheduler.threadName", "MyScheduler"}
                 };

            builder.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = c => schedulerConfig
            });

            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(DownloadCurrenciesJob).Assembly));
            builder.RegisterType<JobScheduler>().AsSelf();
        }
    }
}