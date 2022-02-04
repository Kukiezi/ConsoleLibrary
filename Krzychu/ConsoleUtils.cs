using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    class ConsoleUtils
    {
        public static string GetUserInput(string askForText)
        {
            Console.Clear();
            Console.Write($"{askForText}: ");
            return Console.ReadLine();
        }

        public static void FinishedOperationClickAnyButton(string s)
        {
            Console.WriteLine(s);
            Console.ReadKey();
            Console.Clear();
        }

        public static BookType ChooseType()
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

                else if (choose <= 0 || choose > 8)
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
