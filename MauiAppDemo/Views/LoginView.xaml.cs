using MauiAppDemo.ViewModels;

namespace MauiAppDemo.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}