using CommonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public interface IGroupService
    {
        public List<GroupCommon> GetList();
        public bool Post(string groupName);
    }
}
