using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.Model
{
    class UserLogin
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserLogin(string username, string password)
        {
            Password = password;
            Username = username;
        }
    }
}
