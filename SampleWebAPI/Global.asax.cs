using Autofac;
using Autofac.Integration.WebApi;
using SampleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace SampleWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Install autofac using nuget
            //Autofac configuration
            var container = new ContainerBuilder();
            container.RegisterApiControllers(Assembly.GetExecutingAssembly());
            container.RegisterType<SavingsDBContext>().InstancePerRequest();

            var build = container.Build();
            //  config.DependencyResolver = new AutofacWebApiDependencyResolver(build);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(build);


        }
    }
}
