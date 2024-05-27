using MauiAppDemo.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services.Authentication
{
    public class AuthService : IAuthService
    {
      
        public async Task<bool> LoginAsync(string user, string password)

        {
        
           return await Task.FromResult(user == "admin" && password == "admin");
        }


    }
}
