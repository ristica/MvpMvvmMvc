using Demo.IoC.Contracts;
using Demo.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Demo.IoC;
using Demo.LocalContainer;
using Demo.Services;
using Demo.Views;
using Demo.Views.Contracts;

namespace Demo.Bootstrapper
{
    public sealed class IocManager
    {
        public static void InitializeContainer()
        {
            var container = DependencyContainerFactory.CreateContainer(CreateHostBuilder().Build().Services);
            Host.CreateDefaultBuilder().ConfigureServices((context, services) => services.AddSingleton<ILocalServiceProvider, LocalServiceProvider>());
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    // Factory
                    RegisterFrameworkServices(services);

                    // Services
                    RegisterProjectServices(services);

                    // Forms
                    RegisterForms(services);

                });
        }

        private static void RegisterForms(IServiceCollection services)
        {
            // Forms without parameters (except DI's)
            services.AddTransient<IFormMain, FormMain>();

            //// Forms with parameters (except DI's)
            //services.AddTransient<Func<string, IFormWithParam>>(
            //    container =>
            //        param =>
            //        {
            //            var testService = container.GetRequiredService<ITestService>();
            //            return new FormWithParam(testService, param);
            //        });
        }

        private static void RegisterProjectServices(IServiceCollection services)
        {
            services.AddTransient<ITestService, TestService>();
        }

        private static void RegisterFrameworkServices(IServiceCollection services)
        {
            services.AddSingleton<IFormFactory, FormFactory>();
        }
    }
}
