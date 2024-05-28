using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Services.Authentication;
using MauiAppDemo.ViewModels;
using MauiAppDemo.Views;
using System.Diagnostics;

namespace MauiAppDemo.Shells;

public partial class PrivateShell : Shell
{
    private readonly IAuthService _authService;

    public PrivateShell(IAuthService authService)
    {
        InitializeComponent();
        LogoutCommand = new Command(OnLogout);
        BindingContext = this;  
        _authService = authService;
    }

    private async void OnLogout()
    {
        await _authService.LogoutAsync();
    }

    public Command LogoutCommand { get; }
}
