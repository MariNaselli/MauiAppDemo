using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Messages
{
    public class AuthenticationMessage
    {
        public bool IsAuthenticated { get; }

        public AuthenticationMessage(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }
    }
}
