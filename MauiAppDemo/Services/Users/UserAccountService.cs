using MauiAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services.Users
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserDatabase _userDatabase;
        //private readonly List<User> _userAccounts = new();
        public UserAccountService(UserDatabase userDatabase)
        {
            _userDatabase = userDatabase;
        }
        public async Task AddUserAccountAsync(User user)
        {
            await _userDatabase.SaveUserAsync(user);
        }

        public async Task<List<User>> GetUserAccountsAsync()
        {
            return await _userDatabase.GetUsersAsync();
        }

        //public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        //{
        //    return await _userDatabase.GetUserByUsernameAndPasswordAsync(username, password);
        //}
        //public Task AddUserAccountAsync(User account)
        //{
        //    _userAccounts.Add(account);
        //    return Task.CompletedTask;
        //}

        //public Task<List<User>> GetUserAccountsAsync()
        //{
        //    return Task.FromResult(_userAccounts);
        //}
    }
}
