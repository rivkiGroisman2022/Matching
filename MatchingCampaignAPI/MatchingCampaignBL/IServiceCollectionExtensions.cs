using MatchingCampaignDAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignBL
{
    public static class IServiceCollectionExtensions
    {
        public static void AddBLServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDonationService, DonationService>();
            serviceCollection.AddScoped<ICollectorService, CollectorService>();
            serviceCollection.AddScoped<IMatchingService, MatchingService>();
            serviceCollection.AddScoped<IGroupService, GroupService>();
            serviceCollection.AddRepositories();
        }
    }
}
