using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    class BookFactory
    {
        public static T CreateBook<T>(IBuilder<T> builder) where T: Book
        {
            if (typeof(T) == typeof(Book))
            {
                return (T) new Book((BookBuilder)builder);
            } 

            return default(T);
        }
    }
}
