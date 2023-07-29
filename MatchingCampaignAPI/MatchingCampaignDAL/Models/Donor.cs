using System;
using System.Collections.Generic;

namespace MatchingCampaignDAL.Models
{
    public partial class Donor
    {
        public Donor()
        {
            Donations = new HashSet<Donation>();
        }

        public int Id { get; set; }
        public string DonorName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Adress { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
