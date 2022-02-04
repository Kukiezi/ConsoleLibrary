using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    public class LibraryProfile
    {
        private List<Book> favouriteBooks = new List<Book>();

        public void BorrowBook(Book book)
        {
            Console.Clear();
            favouriteBooks.Add(book);
            Console.WriteLine("Pomyślnie dodano ksiąkę, nacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowBorrowedBooks()
        {
            Console.Clear();
            Console.WriteLine("Wypożyczane książki: ");
            foreach (var book in favouriteBooks)
            {
                Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
            }
            Console.WriteLine("Naciśnij dowolny przycisk by kontynuować");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
