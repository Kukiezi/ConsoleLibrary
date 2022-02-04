using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Krzychu
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookType Type { get; set; }

        public Book() { }
        public Book(BookBuilder builder)
        {
            Type = builder.SetType();
            Title = builder.SetStringValue("Wprowadź Tytuł");
            Author = builder.SetStringValue("Podaj Autora");
        }

        public override string ToString()
        {
            return $"{Title} {Author} {Type}";
        }

        public void EditBook()
        {
            Console.WriteLine("Edytuj tytuł: ");
            Title = Console.ReadLine();
            Console.WriteLine("Edytuj autora: ");
            Author = Console.ReadLine();
            Type = ConsoleUtils.ChooseType();
        }
    }
}
