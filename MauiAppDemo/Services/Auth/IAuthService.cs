using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services.Authentication
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string user, string password);
        Task<bool> IsAuthenticatedAsync();
        Task LogoutAsync();
    }
}
