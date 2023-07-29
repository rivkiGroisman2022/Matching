using CommonClasses;
using MatchingCampaignBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchingCampaignAPI.Controllers
{
    public class GroupsController : BaseController
    {
        private readonly IGroupService groupService;
        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;

        }
        [HttpGet]
        public List<GroupCommon> GetList()
        {
            return groupService.GetList();
        }
        [HttpPost("{name}")]
        public bool Post(string name)
        {
            return groupService.Post(name);
        }
    }
}
