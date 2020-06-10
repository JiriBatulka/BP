using System;
using System.Collections.Generic;

namespace BP.Entities
{
    public partial class Client
    {
        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
    }
}
