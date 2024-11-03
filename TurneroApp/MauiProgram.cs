using TurneroApp.MVVM.ViewModels;
using TurneroApp.MVVM.Views;
using Microsoft.Extensions.Logging;

namespace TurneroApp
{
    public static class MauiProgram
    {
        private const string BaseAddress = "http://localhost:5103/";

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

            // Registro de servicios
            builder.Services.AddSingleton<ApiService>();
            //builder.Services.AddTransient<UsuariosViewModel>();
            //builder.Services.AddTransient<ProductoListaViewModel>();
            //IServiceCollection serviceCollection = builder.Services.AddTransient<UsuarioAgregarViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}