using System;
using System.Collections.Generic;

namespace ServicesAPI.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public int ServiceCost { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
