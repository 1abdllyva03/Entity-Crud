using System;
using System.Collections.Generic;

#nullable disable

namespace task1.Models
{
    public partial class Status
    {
        public Status()
        {
            User1s = new HashSet<User1>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<User1> User1s { get; set; }
    }
}
