using MatchingCampaignDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public interface IMatchingRepository
    {
        public Matching Get();
        public bool Post(DateTime date);
    }
}
