using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls;
using MiAppGastos.Services;
using MiAppGastos.ViewModels;
using MiAppGastos.Views;

namespace MiAppGastos;

#pragma warning disable CA1416
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // INICIALIZACIÓN OBLIGATORIA PARA SQLite EN MAUI
        SQLitePCL.Batteries_V2.Init();

        // Registro de servicios y ViewModels en DI
        builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<AddTransactionViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddTransactionPage>();

        Routing.RegisterRoute(nameof(AddTransactionPage), typeof(AddTransactionPage));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
#pragma warning restore CA1416