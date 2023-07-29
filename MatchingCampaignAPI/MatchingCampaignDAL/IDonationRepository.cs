using CommonClasses;
using MatchingCampaignDAL;
using MatchingCampaignDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public interface IDonationRepository
    {
        List<Donation> GetList();
        List<Donation> GetSpecific(string specific);
        bool Post(FullDonationCommon t);
        bool Put(int id, Donation t);
        bool Delete(int id);
    }
}
