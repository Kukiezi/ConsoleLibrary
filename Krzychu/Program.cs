using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Krzychu
{
    public class Program
    {
        public static string jsonLocation = @"C:\Users\Kuki\Desktop\path123.json";
        Library library;
        static string jsonLibraryFromFile = File.ReadAllText(jsonLocation);

        public Program()
        {
            library = new Library();
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            // BookTypeJsonConverter is a custom JsonDeserializer. Needed it to match json string Type to BookType
            var options = new JsonSerializerOptions();
            options.Converters.Add(new BookTypeJsonConverter());
            p.library.library = JsonSerializer.Deserialize<List<Book>>(jsonLibraryFromFile, options);
            p.ShowMenu();
        }

        void ShowMenu()
        {
            IMenu menu = MenuFactory.CreateMenu(UserService.GetLoggedInUser());
            menu.NavigateMenu(library);
        }
    }
}
