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

        
        Task AddUserAccountAsync(User user);
        Task<List<User>> GetUserAccountsAsync();
    }
}
