using MatchingCampaignDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public interface IGroupRepository
    {
        public List<Group> GetList();
        public bool Post(string groupName);
    }
}
