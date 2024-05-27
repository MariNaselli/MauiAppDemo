using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Messages;
using MauiAppDemo.Services.Authentication;
using MauiAppDemo.Views;
using System.Diagnostics;

namespace MauiAppDemo
{
    public partial class App : Application
    {
        private readonly IAuthService _authService;

        public App(IAuthService authService)
        {
            InitializeComponent();

            _authService = authService;

            // Registrar los mensajes
            WeakReferenceMessenger.Default.Register<AuthenticationMessage>(this, OnAuthenticationMessage);

            // Validar el token al iniciar la aplicación
            ValidateToken();
        }

        private async void ValidateToken()
        {
            if (await _authService.IsAuthenticatedAsync())
            {
                MainPage = new PrivateShell(_authService);
                Shell.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync("//home");
                });
            }
            else
            {
                MainPage = new PublicShell();
                Shell.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync("//login");
                });
            }
        }

        private void OnAuthenticationMessage(object recipient, AuthenticationMessage message)
        {
            if (message.IsAuthenticated)
            {
                Debug.WriteLine("Authentication successful. Changing Shell.");
                MainPage = new PrivateShell(_authService);
                Shell.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync("//home");
                });
            }
            else
            {
                Debug.WriteLine("Logout successful. Changing Shell.");
                MainPage = new PublicShell();
                Shell.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync("//login");
                });
            }
        }

    }
}
