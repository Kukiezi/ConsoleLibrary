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
        public List<Book> library = new List<Book>();
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
            library.Add(book);
            Console.WriteLine("Pomyślnie dodano ksiąkę, nacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }

        public Book CreateBook()
        {
            Book book = new Book();
            book.Type = ChooseType();
            Console.Clear();
            Console.WriteLine($"Wybrany typ to: {book.Type}");
            Console.WriteLine("\nWprowadź tutuł:");
            book.Title = Console.ReadLine();
            Console.WriteLine("\nPodaj autora:");
            book.Author = Console.ReadLine();
            Console.Clear();
            return book;
        }

        public void PrintLibrary()
        {
            int a = 0;
            foreach (var book in library)
            {
                a++;
                Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
            }
        }

        public void ShowFoundBooks(BookType type)
        {
            Console.Clear();
            if (type == BookType.All)
            {
                PrintLibrary();
            } 
            else
            {
                foreach (var book in library)
                {
                    if (type.CompareTo(book.Type) == 0)
                    {
                        Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                    }
                }
            }

            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }

        public int ChooseBook()
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

        public void DeleteBook()
        {
            Console.Clear();
            Console.WriteLine("Wybierz książkę którą chcesz usunąć wpisując jej indeks\n");
            foreach (var books in library)
            {
                int index = library.IndexOf(books);
                Console.WriteLine($"{index} {books.Title} {books.Author} {books.Type}");
            }

            while (true)
                try
                {
                    library.RemoveAt(ChooseBook());
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Błędny indeks");
                }
            Console.Clear();
            Console.WriteLine("Pomyślnie usunięto książkę, nacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void EditBookFromLibrary()
        {
            Console.WriteLine("Wybierz książkę którą chcesz edytować wpisując jej indeks\n");
            foreach (var books in library)
            {
                int index = library.IndexOf(books);
                Console.WriteLine($"{index} {books.Title} {books.Author} {books.Type}");
            }


            while (true)
            {
                int chosenIndex = ChooseBook();
                try
                {
                    library[chosenIndex].Title = "";
                    Console.WriteLine("Edytuj tytuł: ");
                    library[chosenIndex].Title = Console.ReadLine();
                    Console.WriteLine("Edytuj autora: ");
                    library[chosenIndex].Author = Console.ReadLine();
                    library[chosenIndex].Type = ChooseType();
                    break;

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Błędny indeks");
                }
            }
        }

        public Book MoveFromLibraryToBorrowed()
        {
            Console.Clear();
            Console.WriteLine("Wybierz książkę którą chcesz dodać do wypożyczonych wpisując jej indeks\n");
            foreach (var books in library)
            {
                int index = library.IndexOf(books);
                Console.WriteLine($"{index} {books.Title} {books.Author} {books.Type}");
            }
            while (true)
            {
                int chooseBook = ChooseBook();
                try
                {
                    return library[chooseBook];
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Błędny indeks");
                }
            }
        }

        public BookType ChooseType()
        {
            int choose;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Proszę dokonać wyboru kategorii z poniższej listy:\n");
                BookType.PrintAll();
           
                if (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.Clear();
                    Console.WriteLine("Proszę wybrać właściwą kategorię");
                    continue;

                }

                else if (choose <= 0 || choose >= 8)
                {
                    Console.Clear();
                    Console.WriteLine("Proszę wybrać właściwą kategorię");
                    continue;
                }

                return BookType.GetBookType(choose);
            }
        }
    }
}

