
// Services/UserDatabase.cs
using MauiAppDemo.Models;
using SQLite;
using MauiAppDemo.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiAppDemo.Services
{
    public class UserDatabase
    {
        SQLiteAsyncConnection? Database;

        public UserDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<User>();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await Init();
            return await Database.Table<User>().ToListAsync();
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            await Init();
            return await Database.Table<User>().Where(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }

        public async Task<int> SaveUserAsync(User user)
        {
            await Init();
            if (user.Id != 0)
            {
                return await Database.UpdateAsync(user);
            }
            else
            {
                return await Database.InsertAsync(user);
            }
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            await Init();
            return await Database.DeleteAsync(user);
        }
    }
}
