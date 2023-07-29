using System;
using System.Collections.Generic;

namespace MatchingCampaignDAL.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Donations = new HashSet<Donation>();
        }

        public int Id { get; set; }
        public string CreditNumber { get; set; } = null!;
        public string Cvv { get; set; } = null!;
        public DateTime Validity { get; set; }
        public string Idnumber { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
