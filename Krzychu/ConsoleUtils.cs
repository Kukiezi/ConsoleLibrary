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
    }
}
