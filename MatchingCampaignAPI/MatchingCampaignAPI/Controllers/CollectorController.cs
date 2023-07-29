using CommonClasses;
using MatchingCampaignBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchingCampaignAPI.Controllers
{
    public class CollectorController : BaseController
    {
        private readonly ICollectorService collectorService;
        public CollectorController(ICollectorService collectorService)
        {
            this.collectorService = collectorService;
        }

        [HttpGet]
        public List<CollectorCommon> Get()
        {
            //aggregations.Aggregate($"function: {nameof(Get)}, date time: {DateTime.Now}, url: {Request.Path}.");
            return collectorService.GetList();
        }

        [HttpGet("groupId")]
        public List<CollectorCommon> GetByGroup(int groupId)
        {
            return collectorService.GetSpecificByGroup(groupId);
        }

        [HttpGet("{pass}")]
        public CollectorCommon GetByPassword(string pass)
        {
            return collectorService.GetSpecificByPassword(pass);
        }

        [HttpPost("{pass}")]
        public bool Post(string pass, CollectorCommon collectorCommon)
        {
            return collectorService.Post(pass, collectorCommon);
        }

        [HttpPut("{pass}")]
        public bool Put(string pass, double newGoal)
        {
            return collectorService.Put(pass, newGoal);
        }
    }
}
