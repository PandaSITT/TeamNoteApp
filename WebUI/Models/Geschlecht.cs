using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class Geschlecht
    {
        public Geschlecht()
        {
            Users = new HashSet<User>();
        }

        public int GId { get; set; }
        public string GName { get; set; }
        public string GAnrede { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
