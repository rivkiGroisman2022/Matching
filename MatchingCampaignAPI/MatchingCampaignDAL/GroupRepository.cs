using MatchingCampaignDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public class GroupRepository : IGroupRepository
    {
        MatchingContext context;
        public GroupRepository(MatchingContext context)
        {
            this.context = context;
        }

        public List<Models.Group> GetList()
        {
            try
            {
                return context.Groups.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("opssssssss" + ex.Message);
                throw;
            }
        }

        public bool Post(string groupName)
        {
            try
            {
                context.Groups.AddAsync(new Models.Group() { GroupName = groupName });
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("opssssssss" + ex.Message);
                return false;
                throw;
            }
        }
    }
}
