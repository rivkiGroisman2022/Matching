using CommonClasses;
using MatchingCampaignDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    internal class CollectorRepository : ICollectorRepository
    {
        MatchingContext context;

        public CollectorRepository(MatchingContext context)
        {
            this.context = context;
        }
        public List<ManagersAndCollector> GetList()
        {
            try
            {
                return context.ManagersAndCollectors.ToList();
                Console.WriteLine("rtrtr");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ooooooooops" + ex.Message);
                throw;
            }
        }

        public ManagersAndCollector GetSpecificByPassword(string password)
        {
            try
            {
                var result = context.ManagersAndCollectors;
                foreach (var item in result)
                {
                    if (item.Password == password)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ooooooooops" + ex.Message);
                throw;
            }
        }

        public List<ManagersAndCollector> GetSpecificByGroup(int groupId)
        {
            try
            {
                List<ManagersAndCollector> collectors = new();
                var result = context.ManagersAndCollectors;
                foreach (var item in result)
                {
                    if (item.GroupId == groupId)
                    {
                        collectors.Add(item);
                    }
                }
                return collectors;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ooooooooops" + ex.Message);
                throw;
            }
        }

        public bool Post(string password, CollectorCommon collectorCommon)
        {
            var result = context.ManagersAndCollectors.FirstOrDefault(m => m.Password == password);
            if (result != null)
            {
                if (result.PermissionsId == 1)
                {
                    ManagersAndCollector mc = new()
                    {
                        Name = collectorCommon.Name,
                        Goal = collectorCommon.Goal,
                        GroupId = collectorCommon.GroupId,
                        Password = collectorCommon.Password,
                        PermissionsId = 2
                    };
                    context.ManagersAndCollectors.AddAsync(mc);
                    context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public bool Put(string password, double newGoal)
        {
            try
            {
                context.ManagersAndCollectors.FirstOrDefault(m => m.Password == password).Goal = newGoal;
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}