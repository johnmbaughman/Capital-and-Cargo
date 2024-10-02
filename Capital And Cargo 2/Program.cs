using CapitalAndCargo2.Managers;
using CapitalAndCargo2.ViewModels;
using CapitalAndCargo2.Views;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui;

namespace CapitalAndCargo2;

public static class Program
{
    public static IServiceProvider? Services { get; private set; }

    public static void Main(string[] args)
    {
        Services = ConfigureServices();
        Application.Init();
        Application.Run(Services.GetRequiredService<MainView>());
        Application.Top?.Dispose();
        Application.Shutdown();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddTransient<MainView>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<CitiesViewModel>();
        services.AddTransient<CityMarketViewModel>();
        services.AddTransient<TransitViewModel>();
        services.AddTransient(s => new CitiesView(s.GetRequiredService<CitiesViewModel>()));
        services.AddTransient(s => new CityMarketView(s.GetRequiredService<CityMarketViewModel>()));
        services.AddTransient(s => new TransitView(s.GetRequiredService<TransitViewModel>()));
        services.AddSingleton(_ => new DatabaseManager().Initialize());
        services.AddSingleton<PlayerManager>();
        services.AddSingleton<AchievementManager>();
        services.AddSingleton<CargoTypesManager>();
        services.AddSingleton<CitiesManager>();
        services.AddSingleton<FactoryManager>();
        services.AddSingleton<SoundManager>();
        services.AddSingleton<TransitManager>();
        services.AddSingleton<GameDataManager>();
        return services.BuildServiceProvider();
    }
}