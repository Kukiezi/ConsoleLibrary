using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    interface IUserDatabase
    {
        public void Add(User user);
        public User Get(string username);
        public User Get(string username, string password);
    }
}
