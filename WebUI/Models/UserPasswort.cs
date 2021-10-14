using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class UserPasswort
    {
        public int UpUserId { get; set; }
        public string UpPasswort { get; set; }

        public virtual User UpUser { get; set; }
    }
}
