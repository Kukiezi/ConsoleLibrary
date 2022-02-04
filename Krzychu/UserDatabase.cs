using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    public sealed class UserDatabase
    {
        private List<User> users = new List<User>();

        private UserDatabase() { }

        private static UserDatabase instance;

        public static UserDatabase GetInstance()
        {
            if (instance == null)
            {
                instance = new UserDatabase();
                User admin = new User("admin", "12345", Role.ADMIN);
                instance.Add(admin);
            }
            return instance;
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        /// <summary>
        /// Searches for user with specific username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>User or throws error.</returns>
        public User Get(string username)
        {
            User user = users.First(x => x.Username == username);
            if (user == null)
            {
                throw new UserNotFoundException($"User with username {username} was not found in the database.");
            }

            return user;
        }

        /// <summary>
        /// Used to Login User. Searched for user with username nad password.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User or null</returns>
        public User Get(string username, string password)
        {
            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
