using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Campaign : Entity
    {
        public string NameCampaign { get; set; }
        public string TypeCampaign { get; set; }
        public string DescriptionCampaign { get; set; }
        public Guid CustomerSponsor { get; set; }
        public int Enable { get; set; }
    }
}
