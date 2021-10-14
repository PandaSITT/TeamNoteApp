using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class Raeume
    {
        public Raeume()
        {
            Contents = new HashSet<Content>();
            RaumUsers = new HashSet<RaumUser>();
        }

        public int RId { get; set; }
        public string RName { get; set; }
        public int RUserManagerId { get; set; }

        public virtual User RUserManager { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<RaumUser> RaumUsers { get; set; }
    }
}
