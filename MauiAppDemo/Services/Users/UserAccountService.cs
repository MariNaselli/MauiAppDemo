﻿using MauiAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services.Users
{
    public class UserAccountService : IUserAccountService
    {

        public Task<bool> AuthenticateUserAsync(string user, string password)
        {
            return Task.FromResult(user == "admin" && password == "admin");
        }


        private readonly List<UserAccount> _userAccounts = new();

        public Task AddUserAccountAsync(UserAccount account)
        {
            _userAccounts.Add(account);
            return Task.CompletedTask;
        }

        public Task<List<UserAccount>> GetUserAccountsAsync()
        {
            return Task.FromResult(_userAccounts);
        }
    }
}
