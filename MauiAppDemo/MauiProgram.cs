using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Services;
using MauiAppDemo.Services.Authentication;
using MauiAppDemo.Services.Users;
using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MauiAppDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Configurar la lectura del archivo appsettings.json
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MauiAppDemo.appsettings.json");

            //Controlar que que GetManifestResourceStream no devuelva null
            if (stream == null)
            {
                throw new FileNotFoundException("The configuration file 'appsettings.json' was not found as an embedded resource.");
            }

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Obtener la URL base de la API
            var apiUrl = builder.Configuration["ApiUrl"];
            if (string.IsNullOrEmpty(apiUrl))
            {
                throw new InvalidOperationException("The API URL is not configured. Please check appsettings.json.");
            }

            // Registrar HttpClient con la URL base de la configuración en los servicios
            builder.Services.AddHttpClient<IUserAccountService, UserAccountService>(client =>
            {
                client.BaseAddress = new Uri(apiUrl);
            });

            builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
            {
                client.BaseAddress = new Uri(apiUrl);
            });

            // Registrar servicios
            builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            builder.Services.AddSingleton<ICountryService, CountryService>();

            //Registrar Pages y ViewModels
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginViewModel>();

            builder.Services.AddTransient<CreateAccountPage>();
            builder.Services.AddTransient<CreateAccountViewModel>();

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomeViewModel>();

            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfileViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
