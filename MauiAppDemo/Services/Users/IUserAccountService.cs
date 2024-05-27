using MauiAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services.Users
{
    public interface IUserAccountService
    {

        Task<bool> AuthenticateUserAsync(string user, string password);
        Task AddUserAccountAsync(UserAccount account);
        Task<List<UserAccount>> GetUserAccountsAsync();
    }
}
