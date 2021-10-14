using System;
using System.Collections.Generic;

#nullable disable

namespace WebUI.Models
{
    public partial class RaumOverview
    {
        public int RaumId { get; set; }
        public string RaumName { get; set; }
        public string ManagerName { get; set; }
        public int ManagerId { get; set; }
        public long UserCount { get; set; }
    }
}
