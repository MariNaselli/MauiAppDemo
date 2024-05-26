using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Models
{
    public class UserAccount
    {
        public required string User { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string Country { get; set; }
        public required bool AcceptsPrivacyPolicy { get; set; }
        public required bool AcceptsMarketing { get; set; }
    }
}
