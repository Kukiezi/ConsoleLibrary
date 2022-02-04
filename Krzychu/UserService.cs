using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    static class UserService
    {
        static IUserDatabase userDatabase = UserDatabase.GetInstance();
        private static User currentUser;

        public static User GetLoggedInUser()
        {
            return currentUser;
        }

        public static void Logout()
        {
            currentUser = null;
        }

        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("Wprowadź nazwę użytkownika: ");
            string username = Console.ReadLine();
            Console.WriteLine("Wprowadź hasło: ");
            string password = Console.ReadLine();
            User user = new User(username, password, Role.USER);
            userDatabase.Add(user);
            Console.Clear();
            Console.WriteLine("Pomyślnie dodano użytkownika, naciśnij dowolny przycisk aby kontynuować");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Use to perform login. 
        /// If null is returned => failed login
        /// If User object is returned => successful login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User GetUser(string username, string password)
        {
            User user = userDatabase.Get(username, password);
            SetLoggedInUser(user);
            return user;
        }

        private static void SetLoggedInUser(User user)
        {
            currentUser = user;
        }
    }
}
