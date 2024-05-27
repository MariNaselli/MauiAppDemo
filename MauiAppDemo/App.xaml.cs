using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Messages;
using MauiAppDemo.Services.Navigation;
using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;
using System.Diagnostics;

namespace MauiAppDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AuthShell();

            //todo registracion para mensaje de cambio de shell 
            //registra este mensaje y hacer el metodo
            //WeakReferenceMessenger.Default.Register //OnMessageReceived

            WeakReferenceMessenger.Default.Register<NavigateTo>(this, OnNavigateTo);

            Shell.Current.GoToAsync("//login");

        }

        private void OnNavigateTo(object recipient, NavigateTo message)
        {
            
            Shell.Current.Dispatcher.Dispatch(async () =>
            {
                if (message.Route == "//home")
                {
                    MainPage = new AppShell(); 
                }
  
                await NavigationService.NavigateToAsync(message.Route);
                
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
