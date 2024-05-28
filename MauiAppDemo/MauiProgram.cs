﻿using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Services;
using MauiAppDemo.Services.Authentication;
using MauiAppDemo.Services.Users;
using MauiAppDemo.Shells;
using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MauiAppDemo
{
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

            // Registrar servicios
            builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            builder.Services.AddSingleton<ICountryService, CountryService>();
            builder.Services.AddSingleton<IUserAccountService, UserAccountService>();
            builder.Services.AddSingleton<IAuthService, AuthService>();

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
