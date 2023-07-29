using System;
using System.Collections.Generic;

namespace MatchingCampaignDAL.Models
{
    public partial class Donation
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
        public string? ThrowCollectorName { get; set; }
        public int CreditCardId { get; set; }
        public string? Inscription { get; set; }

        public virtual CreditCard CreditCard { get; set; } = null!;
        public virtual Donor Donor { get; set; } = null!;
    }
}
