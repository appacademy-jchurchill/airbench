using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;
using Mvc5Resolver = Unity.Mvc5.UnityDependencyResolver;
using ApiResolver = Unity.WebApi.UnityDependencyResolver;
using AirBench.Data;
using AirBench.Data.Repositories;
using Unity.Lifetime;

namespace AirBench
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IBenchRepository, BenchRepository>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new Mvc5Resolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new ApiResolver(container);
        }
    }
}