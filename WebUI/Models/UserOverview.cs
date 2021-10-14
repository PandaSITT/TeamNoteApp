using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class UserOverview
    {
        public int UserId { get; set; }
        public string Benutzername { get; set; }
        public string Email { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Geschlecht { get; set; }
        public string Rolle { get; set; }
    }
}
