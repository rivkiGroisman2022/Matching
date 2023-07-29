using MatchingCampaignDAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICollectorRepository, CollectorRepository>();
            serviceCollection.AddScoped<IDonationRepository, DonationRepository>();
            serviceCollection.AddScoped<IMatchingRepository, MatchingRepository>();
            serviceCollection.AddScoped<IGroupRepository, GroupRepository>();
            serviceCollection.AddDbContext<MatchingContext>();
        }
    }
}
