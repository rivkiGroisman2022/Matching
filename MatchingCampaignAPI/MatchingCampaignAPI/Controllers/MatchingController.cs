using CommonClasses;
using MatchingCampaignBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchingCampaignAPI.Controllers
{ 
    public class MatchingController : BaseController
    {

        private readonly IMatchingService matchingService;
        public MatchingController(IMatchingService matchingService)
        {
            this.matchingService = matchingService;
        }

        [HttpGet]
        public MatchingCommon Get()
        {
            return matchingService.Get();
        }
        [HttpPost("{date}")]
        public bool Post(DateTime date)
        {
            return matchingService.Post(date);
        }
    }
}
