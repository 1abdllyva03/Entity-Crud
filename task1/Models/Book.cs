using System;
using System.Collections.Generic;

#nullable disable

namespace task1.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public double? BookPrice { get; set; }
        public string Photo { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
