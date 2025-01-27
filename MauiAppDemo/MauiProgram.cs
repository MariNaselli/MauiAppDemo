﻿using MauiAppDemo.ModelsViews;
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

            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddTransient<HomePageView>();
            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<CreateAccountView>();
            builder.Services.AddTransient<CreateAccountViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
