using CommonClasses;
using MatchingCampaignBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchingCampaignAPI.Controllers
{

    public class DonationsController : BaseController
    {
        private readonly IDonationService donationService;
        public DonationsController(IDonationService donationService)
        {
            this.donationService = donationService;
        }
        [HttpGet]
        public List<DonationCommon> Get()
        {
            return donationService.Get();
        }
        [HttpGet("{name}")]
        public List<DonationCommon> GetByCollectorName(string name)
        {
            return donationService.GetSpecific(name);
        }
        [HttpPost]
        public bool Post(FullDonationCommon fullDonationCommon)
        {
            return donationService.Post(fullDonationCommon);
        }
    }
}
