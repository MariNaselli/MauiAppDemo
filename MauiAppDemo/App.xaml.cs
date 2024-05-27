using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Messages;
using MauiAppDemo.Services.Navigation;
using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;

namespace MauiAppDemo
{
    public partial class App : Application
    {
        private readonly IMessenger _messenger;
        public App()
        {
            InitializeComponent();

            MainPage = new AuthShell();
            _messenger = WeakReferenceMessenger.Default;

            _messenger.Register<NavigateTo>(this, OnNavigateTo);
            
            Shell.Current.GoToAsync("//login");

            //todo registracion para mensaje de cambio de shell 
            //registra este mensaje y hacer el metodo
            //WeakReferenceMessenger.Default.Register //OnMessageReceived
        }

        private void OnNavigateTo(object recipient, NavigateTo message)
        {
            Shell.Current.Dispatcher.Dispatch(async () =>
            {
                if (message.Route == "///home")
                {
                    MainPage = new AppShell();
                    await Shell.Current.GoToAsync("//home");
                }
                else
                {
                    await NavigationService.NavigateToAsync(message.Route);
                }
            });
        }

        //private void OnNavigateTo(object recipient, NavigateTo message)
        //{
        //    Shell.Current.Dispatcher.Dispatch(async () =>
        //    {
        //        await NavigationService.NavigateToAsync(message.Route);
        //    });
        //}


        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    _messenger.Register<NavigateTo>(this, async (r, m) => await NavigationService.NavigateToAsync(m.Route));
        //}


        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    _messenger.Unregister<NavigateTo>(this);
        //}
    }
}
