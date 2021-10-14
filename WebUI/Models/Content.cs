using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class Content
    {
        public int CId { get; set; }
        public int CRaumId { get; set; }
        public int CUserCreatorId { get; set; }
        public string CText { get; set; }
        public bool CPinned { get; set; }

        public virtual Raeume CRaum { get; set; }
        public virtual User CUserCreator { get; set; }
    }
}
