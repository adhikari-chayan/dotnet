using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {

            //I need to build my container builder and then I can start telling this builder about the different abstractions that are in my application.
            var builder = new ContainerBuilder();

            //The first thing I'm going to do is register my controllers
            //All I need to do is tell Autofac what assembly contains the controllers for my application. So I'm going to use typeof MvcApplication here. So it's essentially the class that represents this application. This class will be compiled into an assembly, which is the OdeToFood.Web assembly, and it is this assembly that contains MvcApplication that I want Autofac to use.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Similarly registering Api Controllers
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            //And now it's my opportunity to also tell the ContainerBuilder about the specific services I have. So I can say dear builder, I want you to register a type. 

            //builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance();
            builder.RegisterType<SqlRestaurantData>().As<IRestaurantData>().InstancePerRequest();
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();


            //So if I go to the builder object and tell it to build the container
            var container = builder.Build();

            //I now have something that I can give to the MVC 5 framework to tell the framework whenever you need to resolve dependencies, please use this container. And I can do that by going to a class known as the DependencyResolver, and this is a class that is defined by the MVC 5 framework. So I need to go to DependencyResolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Setting Autofac as the dependency resolver for the Web API framework as well
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}