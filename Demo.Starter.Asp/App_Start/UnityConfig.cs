using System.Web.Mvc;
using Demo.Bootstrapper.Asp;
using Demo.Dependencies.Builder;
using Unity;
using Unity.Mvc5;

namespace Demo.Starter.Asp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            DependencyInitializer.Initialize(DependencyContainerFactory.Init());
            DependencyResolver.SetResolver(new CustomDependencyResolver(DependencyContainerFactory.Container));
        }
    }
}