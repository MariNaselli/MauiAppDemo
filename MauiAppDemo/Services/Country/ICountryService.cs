using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services
{
    public interface ICountryService
    {
        Task<List<string>> GetCountriesAsync();
    }
}
