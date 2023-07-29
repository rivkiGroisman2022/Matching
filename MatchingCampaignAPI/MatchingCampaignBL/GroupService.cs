using CommonClasses;
using MatchingCampaignDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public class GroupService : IGroupService
    {
        IGroupRepository groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }
        public List<GroupCommon> GetList()
        {
            var result = groupRepository.GetList();
            return result.Select(g => new GroupCommon()
            {
               Name= g.GroupName
            }
            ).ToList();
        }

        public bool Post(string groupName)
        {
            return groupRepository.Post(groupName);
        }
    }
}
