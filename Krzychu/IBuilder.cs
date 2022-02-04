using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krzychu
{
    public interface IBuilder<T> where T : Book
    {
        public T Build();

        public string SetStringValue(string s);
    }
}
