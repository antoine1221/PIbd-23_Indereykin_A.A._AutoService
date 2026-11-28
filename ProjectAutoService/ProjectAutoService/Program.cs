using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectAutoService.Data;
using ProjectAutoService.Repositories;
using ProjectAutoService.Repositories.Implementations;
using Serilog;
using Unity;
using Unity.Lifetime;

namespace ProjectAutoService;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        try
        {
            if (!DesktopDatabaseStartup.Prepare()) return;
            using var container = CreateContainer();
            Application.Run(container.Resolve<FormAutoService>());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.GetBaseException().Message, "Не удалось запустить автосервис", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally { DataContext.DesktopPassword = null; }
    }

    private static IUnityContainer CreateContainer()
    {
        using var configuration = new ConfigurationManager();
        configuration.SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json");
        var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        var factory = LoggerFactory.Create(builder => builder.AddSerilog(logger, dispose: true));

        var container = new UnityContainer();
        container.RegisterInstance<ILoggerFactory>(factory);
        container.RegisterType(typeof(ILogger<>), typeof(Logger<>));
        container.RegisterType<DataContext>(new TransientLifetimeManager());
        container.RegisterInstance<Func<DataContext>>(() => container.Resolve<DataContext>());
        container.RegisterType<IMechanicRepository, MechanicRepository>();
        container.RegisterType<ISparePartRepository, SparePartRepository>();
        container.RegisterType<IServiceWorkRepository, ServiceWorkRepository>();
        container.RegisterType<IServiceOrderRepository, ServiceOrderRepository>();
        container.RegisterType<IPartUsageRepository, PartUsageRepository>();
        return container;
    }
}
