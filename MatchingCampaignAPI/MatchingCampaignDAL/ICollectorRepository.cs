using CommonClasses;
using MatchingCampaignDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public interface ICollectorRepository
    {
        public List<ManagersAndCollector> GetList();

        public ManagersAndCollector GetSpecificByPassword(string password);

        public List<ManagersAndCollector> GetSpecificByGroup(int groupId);

        public bool Post(string password, CollectorCommon managersAndCollector);

        public bool Put(string password, double newGoal);
    }
}
