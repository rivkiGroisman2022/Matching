using System;
using System.Collections.Generic;

namespace MatchingCampaignDAL.Models
{
    public partial class PermissionsT
    {
        public PermissionsT()
        {
            ManagersAndCollectors = new HashSet<ManagersAndCollector>();
        }

        public int Id { get; set; }
        public string Job { get; set; } = null!;

        public virtual ICollection<ManagersAndCollector> ManagersAndCollectors { get; set; }
    }
}
