using System;
using System.Collections.Generic;

namespace MatchingCampaignDAL.Models
{
    public partial class Matching
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public double Goal { get; set; }
        public double CurrentGoal { get; set; }
        public DateTime EndDate { get; set; }
    }
}
