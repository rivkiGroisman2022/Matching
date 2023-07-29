using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public interface IMatchingService
    {
        public MatchingCommon Get();
        public bool Post(DateTime date);
    }
}
