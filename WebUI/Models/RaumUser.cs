using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class RaumUser
    {
        public int RuRaumId { get; set; }
        public int RuUserId { get; set; }
        public bool RuRaumAdmin { get; set; }

        public virtual Raeume RuRaum { get; set; }
        public virtual User RuUser { get; set; }
    }
}
