﻿using System;
using System.Collections.Generic;

#nullable disable

namespace task1.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
