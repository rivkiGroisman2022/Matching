using System;
using System.Collections.Generic;

namespace MatchingCampaignDAL.Models
{
    public partial class Group
    {
        public Group()
        {
            ManagersAndCollectors = new HashSet<ManagersAndCollector>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; } = null!;

        public virtual ICollection<ManagersAndCollector> ManagersAndCollectors { get; set; }
    }
}
