﻿using System;
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
    }
}
