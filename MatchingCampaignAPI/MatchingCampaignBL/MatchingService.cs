using CommonClasses;
using MatchingCampaignDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public class MatchingService : IMatchingService
    {
        IMatchingRepository matchingRepository;
        public MatchingService(IMatchingRepository matchingRepository)
        {
            this.matchingRepository = matchingRepository;
        }
        public MatchingCommon Get()
        {
            var result = matchingRepository.Get();
            MatchingCommon matchingCommon = new MatchingCommon()
            {
                MatchingName = result.CompanyName,
                Goal = result.Goal,
                CurrentSum = result.CurrentGoal,
                EndDate = result.EndDate
            };
            return matchingCommon;
        }   

        public bool Post(DateTime date)
        {
            return matchingRepository.Post(date);
        }
    }
}
