using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    public class BookBuilder: IBuilder<Book>
    {
        public BookType SetType()
        {
            var bookType = ConsoleUtils.ChooseType();
            Console.Clear();
            Console.WriteLine($"Wybrany typ to: {bookType}");
            return bookType;
        }

        public string SetStringValue(string consoleText)
        {
            return ConsoleUtils.GetUserInput(consoleText);
        }

        public Book Build()
        {
            return BookFactory.CreateBook(this); 
        }
    }
}
