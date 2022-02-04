using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Krzychu
{
    class AdminMenu: IMenu
    {
        public void NavigateMenu(Library library)
        {
            while (true)
            {
                Console.Clear();
                ShowMenu();
                switch (GetUserChoice())
                {
                    case 1:
                        library.AddBook(library.CreateBook());
                        string jsonLibrary = JsonSerializer.Serialize(library.library);
                        File.WriteAllText(Program.jsonLocation, jsonLibrary);
                        break;
                    case 2:
                        library.ShowFoundBooks(library.ChooseType());
                        break;
                    case 3:
                        library.DeleteBook();
                        break;
                    case 4:
                        library.EditBookFromLibrary();
                        break;
                    case 7:
                        Console.Clear();
                        UserService.Logout();
                        IMenu menu = MenuFactory.CreateMenu(UserService.GetLoggedInUser());
                        menu.NavigateMenu(library);
                        break;
                }
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("MENU GŁÓWNE\n");
            Console.WriteLine("1: Dodaj książki");
            Console.WriteLine("2: Przeglądaj książki");
            Console.WriteLine("3: Usuń książki");
            Console.WriteLine("4: Edytuj książki");
            Console.WriteLine("5: Zapisz listę");
            Console.WriteLine("6: Wczytaj listę");
            Console.WriteLine("7: Zamknij program");
            Console.WriteLine("\nCo chcesz zrobić? :");
        }

        private int GetUserChoice()
        {
            int navigate;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-7:");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 7)
                    {
                        break;
                    }
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-7:");
                }
            }
            return navigate;
        }

     
    }
}
