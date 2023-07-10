using System;
using System.Collections.Generic;

#nullable disable

namespace task1.Models
{
    public partial class User1
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
