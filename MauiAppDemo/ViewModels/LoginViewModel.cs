using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Messages;
using MauiAppDemo.Services.Users;
using MauiAppDemo.Views;

namespace MauiAppDemo.ViewModels;

public partial class LoginViewModel : ObservableObject
{

    [ObservableProperty]
    private string user;

    [ObservableProperty]
    private string password;

    //[ObservableProperty]
    //private bool isOk = false;

    private readonly IMessenger _messenger;
    private readonly IUserAccountService _userAccountService;

    public LoginViewModel(IMessenger messenger , IUserAccountService userAccountService) 
    {
        _messenger = messenger;
        _userAccountService = userAccountService;
        user = string.Empty;
        password = string.Empty;
    }

    [RelayCommand]
    public async Task Login()
    {
        if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password))
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Please enter both username and password.", "OK");
            }
            return;
        }

        if (User == "admin" && Password == "admin")
        {
            _messenger.Send(new NavigateTo("home"));
        }
        else
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password. Please try again.", "OK");
            }
        }
        //todo envio mensaje para cambiar shell 

    }

    [RelayCommand]
    public void NavigateToCreateAccount()
    {
        _messenger.Send(new NavigateTo("createaccount"));
    }
}
