using System;
using System.Collections.Generic;

namespace MatchingCampaignDAL.Models
{
    public partial class ManagersAndCollector
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? GroupId { get; set; }
        public string Password { get; set; } = null!;
        public int PermissionsId { get; set; }
        public double Goal { get; set; }
        public double CurrentSum { get; set; }

        public virtual Group? Group { get; set; }
        public virtual PermissionsT Permissions { get; set; } = null!;
    }
}
