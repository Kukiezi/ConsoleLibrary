using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    class UserMenu: IMenu
    {
        public void NavigateMenu(Library library)
        {
            Console.Clear();
            LibraryProfile profile = library.GetUserLibraryProfile(UserService.GetLoggedInUser());
            while (true)
            {
                ShowMenu();
                switch (GetUserChoice())
                {
                    case 1:
                        library.ShowFoundBooks(library.ChooseType());
                        break;
                    case 2:
                        profile.BorrowBook(library.MoveFromLibraryToBorrowed());
                        break;
                    case 3:
                        profile.ShowBorrowedBooks();
                        break;
                    case 4:
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
            Console.WriteLine("1: Przeglądaj książki");
            Console.WriteLine("2: Dodaj książki do wypożyczenia");
            Console.WriteLine("3: Zobacz wypożyczane książki");
            Console.WriteLine("4: Powróć do ekranu logowania");
        }

        public int GetUserChoice()
        {
            int navigate;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 4)
                    {
                        break;
                    }
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
            }
            return navigate;
        }
    }
}
