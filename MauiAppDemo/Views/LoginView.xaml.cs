using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Messages;
using MauiAppDemo.Services.Navigation;
using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views
{
    public partial class LoginView : ContentPage
    {
        //private readonly IMessenger _messenger;

        public LoginView(LoginViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
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
