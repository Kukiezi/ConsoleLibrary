using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    public class BookType: Enumeration
    {
        public static readonly BookType Fantastyka = new BookType(1, "Fantastyka");
        public static readonly BookType Kryminał = new BookType(2, "Kryminał");
        public static readonly BookType Romans = new BookType(3, "Romans");
        public static readonly BookType Naukowa = new BookType(4, "Naukowa");
        public static readonly BookType Dramat = new BookType(5, "Dramat");
        public static readonly BookType Dziecięca = new BookType(6, "Dziecięca");
        public static readonly BookType Obyczajowa = new BookType(7, "Obyczajowa");
        public static readonly BookType All = new BookType(8, "Wszystkie");

        public BookType(int id, string name): base(id, name) { }

        public static BookType GetBookType(int id)
        {
            return GetAll<BookType>().First(x => x.Id == id);
        }

        public static BookType GetBookType(string name)
        {
            return GetAll<BookType>().First(x => x.Name == name);
        }
        public static int GetBookTypesCount()
        {
            return GetAll<BookType>().Count();
        }

        public static void PrintAll()
        {
            var bookTypes = GetAll<BookType>();
            foreach (var bookType in bookTypes)
            {
                Console.WriteLine($"{bookType.Id} {bookType.Name}");
            }
        }
    }
}
