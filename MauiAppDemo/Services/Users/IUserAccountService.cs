using Entities;

namespace MauiAppDemo.Services.Users
{
    public interface IUserAccountService
    {

        
        Task AddUserAccountAsync(User user);
        Task<List<User>> GetUserAccountsAsync();
    }
}
