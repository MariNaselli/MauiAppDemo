using CommunityToolkit.Mvvm.Messaging;
using CoreData;
using MauiAppDemo.Messages;
using MauiAppDemo.Services.Authentication;
using MauiAppDemo.Services.Navigation;
using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            //_messenger = WeakReferenceMessenger.Default;
        }



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
