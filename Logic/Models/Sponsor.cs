using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Sponsor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
