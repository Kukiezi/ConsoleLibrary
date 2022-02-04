using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    class MenuFactory
    {
        public static IMenu CreateMenu(User user)
        {
            if (user == null)
            {
                return new LoginMenu();
            }

            return user.Role switch
            {
                Role.ADMIN => new AdminMenu(),
                Role.USER => new UserMenu(),
                _ => new LoginMenu(),
            };
        }
    }
}
