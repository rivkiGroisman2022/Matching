using CommonClasses;
using MatchingCampaignDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public class CollectorService : ICollectorService
    {

        ICollectorRepository collectorRepository;
        public CollectorService(ICollectorRepository collectorRepository)
        {
            this.collectorRepository = collectorRepository;
        }

        public List<CollectorCommon> GetList()
        {
            try
            {
                var result = collectorRepository.GetList();
                return result.Select(collector => new CollectorCommon()
                {
                    Name = collector.Name,
                    Goal = collector.Goal,
                    CurrentSum = collector.CurrentSum
                }
                ).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"oooooooooops {ex.Message}");
                throw;
            }

        }

        public List<CollectorCommon> GetSpecificByGroup(int groupId)
        {
            try
            {
                var result = collectorRepository.GetSpecificByGroup(groupId);
                return result.Select(collector => new CollectorCommon()
                {
                    Name = collector.Name,
                    Goal = collector.Goal,
                    CurrentSum = collector.CurrentSum
                }
                ).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"oooooooooops {ex.Message}");
                throw;
            }

        }

        public CollectorCommon GetSpecificByPassword(string password)
        {
            try
            {
                var result = collectorRepository.GetSpecificByPassword(password);
                if (result != null)
                {
return new CollectorCommon()
                {
                    Name = result.Name,
                    Goal = result.Goal,
                    CurrentSum = result.CurrentSum
                };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"oooooooooops {ex.Message}");
                throw;
            }

        }

        public bool Post(string password, CollectorCommon collectorCommon)
        {
            try
            {
                return collectorRepository.Post(password, collectorCommon);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"oooooooooops {ex.Message}");
                throw;
            }

        }

        public bool Put(string password, double newGoal)
        {
            try
            {
                return collectorRepository.Put(password, newGoal);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"oooooooooops {ex.Message}");
                throw;
            }

        }
    }
}
