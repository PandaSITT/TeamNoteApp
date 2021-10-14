using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class UserRolle
    {
        public UserRolle()
        {
            Users = new HashSet<User>();
        }

        public int UrId { get; set; }
        public string UrName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
