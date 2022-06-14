using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Sponsor : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
