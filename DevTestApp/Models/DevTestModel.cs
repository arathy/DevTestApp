using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevTestApp.Models
{
    public class RealTimeVotes
    {
        [Key]
        public int Id { get; set; }
        public string  CampaignName { get; set; }
        public DateTime Date { get; set; }
        public int Clicks { get; set; }
        public int Impressions { get; set; }
        public string AffiliateName { get; set; }
    }
}