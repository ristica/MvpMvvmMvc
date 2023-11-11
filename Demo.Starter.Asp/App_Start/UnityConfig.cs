using System.Web.Mvc;
using Demo.Bootstrapper.Asp;
using Demo.Dependencies.Builder;

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