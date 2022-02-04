using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Krzychu
{
    public class Library
    {
        public List<Book> books = new List<Book>();
        public Dictionary<User, LibraryProfile> userProfile = new Dictionary<User, LibraryProfile>();

        public LibraryProfile GetUserLibraryProfile(User user)
        {
            LibraryProfile profile = userProfile.GetValueOrDefault(user);
            if (profile == null)
            {
                userProfile.Add(user, new LibraryProfile());
            }

            return userProfile.GetValueOrDefault(user);
        }

        public void AddBook(Book book)
        {
            Console.Clear();
            books.Add(book);
            ConsoleUtils.FinishedOperationClickAnyButton("Pomyślnie dodano ksiąkę, nacisnij dowolny przycisk aby powrócić do menu");
        }
     
        public void ShowFoundBooks(BookType type)
        {
            Console.Clear();
            if (type == BookType.All)
            {
                Console.WriteLine(this.ToString());
            } 
            else
            {
                // LINQ fun. Probably less performance here as I create new copy of List. Still nice to learn.
                books.Where<Book>(x => type.CompareTo(x.Type) == 0).ToList().ForEach(x => Console.WriteLine(x.ToString()));
            }
            ConsoleUtils.FinishedOperationClickAnyButton("Nacisnij dowolny przycisk aby powrócić do menu");
        }

        public void DeleteBook()
        {
            Console.Clear();
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz usunąć wpisując jej indeks\n");

            books.RemoveAt(GetBookFromConsole<int>());
          
            ConsoleUtils.FinishedOperationClickAnyButton("Pomyślnie usunięto książkę, nacisnij dowolny przycisk aby powrócić do menu");
        }

        public void EditBookFromLibrary()
        {
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz edytować wpisując jej indeks\n");
            GetBookFromConsole<Book>().EditBook();
        }

        public T GetBookFromConsole<T>() 
        {
            Console.Clear();
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz dodać do wypożyczonych wpisując jej indeks\n");
         
            while (true)
            {
                int chooseBook = ChooseBook();
                try
                {
                    if (typeof(T) == typeof(Book))
                    {
                        return (T)Convert.ChangeType(books[chooseBook], typeof(T));
                    }
                    if (typeof(T) == typeof(int))
                    {
                        int t = Convert.ToInt32(chooseBook);
                        return (T)Convert.ChangeType(chooseBook, typeof(T));
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Błędny indeks");
                }
            }
        }

        private int ChooseBook()
        {
            int choose;
            while (true)
            {

                if (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.WriteLine("Proszę wybrać numer");
                }
                else break;
            }

            return choose;
        }

        private void PrintBooksWithTextBefore(string s)
        {
            Console.WriteLine(s);
            foreach (var book in books)
            {
                int index = this.books.IndexOf(book);
                Console.WriteLine($"{index} {book}");
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (var book in books)
            {
                s += $"{book.Title} {book.Author} {book.Type}\n";
            }
            return s;
        }

    }
}

