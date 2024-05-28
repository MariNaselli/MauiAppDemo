
using Entities;
using System.Net.Http.Json;

namespace MauiAppDemo.Services.Users
{
    public class UserAccountService : IUserAccountService
    {
        private readonly HttpClient _httpClient;

        public UserAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddUserAccountAsync(User userAccount)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/users/register", userAccount);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<User>> GetUserAccountsAsync()
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>("/api/users/all");
            return users ?? new List<User>();
        }
    }
}
