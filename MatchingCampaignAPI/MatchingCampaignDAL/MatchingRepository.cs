using MatchingCampaignDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public class MatchingRepository : IMatchingRepository
    {
        MatchingContext context;
        public MatchingRepository(MatchingContext context)
        {
            this.context = context;
        }
        public Matching Get()
        {
            try
            {
                return context.Matchings.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public bool Post(DateTime date)
        {
            try
            {
                context.Matchings.First().EndDate = date;
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
