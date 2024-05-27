using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;
using System.Diagnostics;

namespace MauiAppDemo;

public partial class AppShell : Shell
{
    public AppShell()
    {

        InitializeComponent();
        LogoutCommand = new Command(OnLogout);
        BindingContext = this;  

    }

    private static async void OnLogout()
    {
        Application.Current.MainPage = new AuthShell();
        await Shell.Current.GoToAsync("//login");
    }

    public Command LogoutCommand { get; }
}
