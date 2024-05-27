using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services.Navigation
{
    public static class NavigationService
    {
        public static async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}


