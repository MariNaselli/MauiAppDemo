﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services.Authentication
{
    public interface IAuthService
    {
        Task LoginAsync(string username, string password);
        Task<bool> IsAuthenticatedAsync();
        Task LogoutAsync();
    }
}
