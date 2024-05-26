using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Services
{
    public class CountryService : ICountryService
    {
        public Task<List<string>> GetCountriesAsync()
        {
            var countries = new List<string>
            {
                "United States",
                "Canada",
                "United Kingdom",
                "Argentina",
                "Germany",
                "France",
                "Japan",
                "China",
                "Brazil",
                "Italia"
            };

            return Task.FromResult(countries);
        }
    }
}
