using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BarApp.Services.Interfaces;
using BarApp.Services;

namespace BarApp;

public static class MauiProgram
{
    private static MauiApp _app;
    public static IServiceProvider ServiceProvider => _app.Services;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }
            );

        // Burada servislerimizi DI konteynırına ekliyoruz:
        builder.Services.AddSingleton<IFavoritesService, FavoritesServiceMock>();
            builder.Services.AddSingleton<IBarService, BarServiceMock>();

        //    return builder.Build();
        _app = builder.Build();
        return _app;
    }
    }

