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
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;
   
    public LoginViewModel(IAuthService authService) 
    {
        _authService = authService;
        username = string.Empty;
        password = string.Empty;
    }

    [RelayCommand]
    public async Task Login()
    {

        if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
        {
            await _authService.LoginAsync(Username, Password);
        }
    }

    //Esto no se està usando porque el Command se està definiendo directamente en la shell privada .cs

    [RelayCommand]
    public async Task Logout()
    {
        await _authService.LogoutAsync();
    }
}
