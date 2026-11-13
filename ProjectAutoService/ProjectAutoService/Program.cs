using ProjectAutoService.Repositories;
using ProjectAutoService.Repositories.Implementations;
using Unity;
using Unity.Lifetime;

namespace ProjectAutoService
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(CreateContainer().Resolve<FormAutoService>());
        }

        private static IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IMechanicRepository, MechanicRepository>(new TransientLifetimeManager());
            container.RegisterType<ISparePartRepository, SparePartRepository>(new TransientLifetimeManager());
            container.RegisterType<IServiceWorkRepository, ServiceWorkRepository>(new TransientLifetimeManager());
            container.RegisterType<IServiceOrderRepository, ServiceOrderRepository>(new TransientLifetimeManager());
            container.RegisterType<IPartUsageRepository, PartUsageRepository>(new TransientLifetimeManager());
            return container;
        }
    }
}