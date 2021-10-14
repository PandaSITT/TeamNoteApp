using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class User
    {
        public User()
        {
            Contents = new HashSet<Content>();
            Raeumes = new HashSet<Raeume>();
            RaumUsers = new HashSet<RaumUser>();
        }

        public int UId { get; set; }
        public string UBenutzername { get; set; }
        public string UEmail { get; set; }
        public string UVorname { get; set; }
        public string UNachname { get; set; }
        public int? UGeschlechtId { get; set; }
        public int URolleId { get; set; }

        public virtual Geschlecht UGeschlecht { get; set; }
        public virtual UserRolle URolle { get; set; }
        public virtual UserPasswort UserPasswort { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Raeume> Raeumes { get; set; }
        public virtual ICollection<RaumUser> RaumUsers { get; set; }
    }
}
