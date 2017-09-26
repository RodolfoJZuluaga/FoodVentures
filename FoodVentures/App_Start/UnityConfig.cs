using FoodVentures.Controllers;
using FoodVentures.Services;
using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;
using Unity.Mvc5;
using System.Web.Configuration;

namespace FoodVentures
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IFoodService, FoodService>();
            container.RegisterType<IFoodTagsService, FoodTagsService>();
            container.RegisterType<ITagsService, TagsService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}