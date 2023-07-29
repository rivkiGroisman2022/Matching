using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class FullDonationCommon
    {
        public DonationCommon DonationCommon { get; set; } = null!;
        public string ThrowCollectorName { get; set; } = null!;
        public DonorCommon DonorCommon { get; set; } = null!;
        public CreditCardCommon CreditCard { get; set; } = null!;

    }
}
