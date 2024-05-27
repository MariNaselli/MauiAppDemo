using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Messages;
using MauiAppDemo.Services.Authentication;
using MauiAppDemo.Services.Users;
using MauiAppDemo.Views;

namespace MauiAppDemo.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IMessenger _messenger;
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string user;

    [ObservableProperty]
    private string password;
   
    public LoginViewModel(IMessenger messenger, IAuthService authService) 
    {
        _messenger = messenger;
        _authService = authService;
        user = string.Empty;
        password = string.Empty;
    }

    [RelayCommand]
    public async Task Login()
    {

        if (!string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Password))
        {
            await _authService.LoginAsync(User, Password);
        }
    }

    [RelayCommand]
    public async Task Logout()
    {
        await _authService.LogoutAsync();
    }
}
