﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppDemo.Messages;
using MauiAppDemo.Models;
using MauiAppDemo.Services;
using MauiAppDemo.Services.Users;
using MauiAppDemo.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiAppDemo.ViewModels
{
    public partial class CreateAccountViewModel : ObservableObject
    {
        private readonly IMessenger _messenger;
        private readonly ICountryService _countryService;
        private readonly IUserAccountService _userAccountService;

        [ObservableProperty]
        private string user;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string country;

        [ObservableProperty]
        private ObservableCollection<string> countries;

        [ObservableProperty]
        private bool acceptsPrivacyPolicy;

        [ObservableProperty]
        private bool acceptsMarketing;

        public CreateAccountViewModel(ICountryService countryService, IUserAccountService userAccountService, IMessenger messenger)
        {
            _countryService = countryService;
            _userAccountService = userAccountService;
            _messenger = messenger;
            User = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            Name = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            Country = string.Empty;
            AcceptsPrivacyPolicy = false;
            AcceptsMarketing = false;
            Countries = new ObservableCollection<string>();
            LoadCountries();
        }

        private async void LoadCountries()
        {
            var countryList = await _countryService.GetCountriesAsync();
            Countries = new ObservableCollection<string>(countryList);
        }

        [RelayCommand]
        public async Task CreateAccount()
        {
            if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword) ||
                string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Address))
            {
                //Error
                return;
            }

            if (Password != ConfirmPassword)
            {
                //Error
                return;
            }

            var newAccount = new UserAccount
            {
                User = User,
                Password = Password,
                Name = Name,
                LastName = LastName,
                Address = Address,
                Country = Country,
                AcceptsPrivacyPolicy = AcceptsPrivacyPolicy,
                AcceptsMarketing = AcceptsMarketing
            };

            await _userAccountService.AddUserAccountAsync(newAccount);

            _messenger.Send(new NavigateTo("home"));
        }
    }
}