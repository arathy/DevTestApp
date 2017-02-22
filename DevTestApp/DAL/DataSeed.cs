using System;
using System.Collections.Generic;
using System.Linq;
using DevTestApp.Models;
using System.Data.Entity;

namespace DevTestApp.DAL
{
    public class DataSeed : DropCreateDatabaseIfModelChanges<DevTestContext>
    {
        protected override void Seed(DevTestContext context)
        {
            var votes = new List<RealTimeVotes>
            {
                new RealTimeVotes
                {
                    AffiliateName = "Affiliate 1", CampaignName = "Campaign 1",Clicks = 10, Date = DateTime.Now , Impressions = 10

                },
                 new RealTimeVotes
                {
                    AffiliateName = "Affiliate 2", CampaignName = "Campaign 2",Clicks = 12, Date = DateTime.Now , Impressions = 10

                },
                  new RealTimeVotes
                {
                    AffiliateName = "Affiliate 3", CampaignName = "Campaign 3",Clicks = 10, Date = DateTime.Now , Impressions = 10

                },
                   new RealTimeVotes
                {
                    AffiliateName = "Affiliate 4", CampaignName = "Campaign 4",Clicks = 10, Date = DateTime.Now , Impressions = 10

                },
                    new RealTimeVotes
                {
                    AffiliateName = "Affiliate 8", CampaignName = "Campaign 6",Clicks = 10, Date = DateTime.Now , Impressions = 10

                },
                     new RealTimeVotes
                {
                    AffiliateName = "Affiliate 7", CampaignName = "Campaign 7",Clicks = 10, Date = DateTime.Now , Impressions = 10
                }

            };

            votes.ForEach(c => context.RealTimeVotes.Add(c));
            context.SaveChanges();
        }
    }
}