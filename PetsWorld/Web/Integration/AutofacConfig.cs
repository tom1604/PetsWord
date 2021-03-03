using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;


namespace Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();

            // Register your MVC controllers.
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            containerBuilder.RegisterFilterProvider();
            var asseamblyServices = Assembly.Load("Business");
            var asseamblyInterfaces = Assembly.Load("Interfaces");

            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired().InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes(asseamblyServices).AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes(asseamblyInterfaces).AsSelf().PropertiesAutowired().InstancePerLifetimeScope();

            var container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}