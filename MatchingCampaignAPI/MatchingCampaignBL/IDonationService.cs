using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public interface IDonationService
    {
        public List<DonationCommon> Get();
        public List<DonationCommon> GetSpecific(string name);
        public bool Post(FullDonationCommon fullDonationCommon);
    }
}
