using CommonClasses;
using MatchingCampaignDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public interface ICollectorService
    {
        public List<CollectorCommon> GetList();
        public List<CollectorCommon> GetSpecificByGroup(int groupId);
        public CollectorCommon GetSpecificByPassword(string password);
        public bool Put(string password, double newGoal);
        public bool Post(string password, CollectorCommon collectorCommon);
    }
}
