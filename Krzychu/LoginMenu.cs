using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    public class LoginMenu : IMenu
    {
        public void NavigateMenu(Library library)
        {
            IMenu menu = MenuFactory.CreateMenu(UserService.GetLoggedInUser());
            ShowMenu();
            switch (GetUserChoice())
            {
                case 1:
                    User user = UserService.GetUser(ConsoleUtils.GetUserInput("Username"), ConsoleUtils.GetUserInput("Password"));
                    if (user != null)
                    {
                        menu = MenuFactory.CreateMenu(user);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Błędne dane do logowania");
                        break;
                    }
                case 2:
                    UserService.Register();
                    break;
                case 3:
                    Console.WriteLine("Do widzenia!");
                    Environment.Exit(0);
                    break;
            }
            menu.NavigateMenu(library);
        }

        private void ShowMenu()
        {
            Console.WriteLine("Witaj w bibliotece online\n");
            Console.WriteLine("1 Zaloguj się");
            Console.WriteLine("2 Zarejestruj się");
            Console.WriteLine("3 Wyjdź");
        }

        private int GetUserChoice()
        {
            int navigate;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-3:");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 4)
                    {
                        break;
                    }
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-3:");
                }
            }
            return navigate;
        }

    }
}
