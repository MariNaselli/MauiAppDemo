using SQLite;

namespace MauiAppDemo.Models
{
    public class User
    {
        public User()
        {
          
        }

        [PrimaryKey, AutoIncrement]
        public required int Id { get; set; }


        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string Country { get; set; }
        public required bool AcceptsPrivacyPolicy { get; set; }
        public required bool AcceptsMarketing { get; set; }
    }
}
