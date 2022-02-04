using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    public enum Role
    {
        ADMIN, USER,
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; private set; }
        public Role Role { get; set; }

        public User(string username, string password, Role role = Role.USER)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
