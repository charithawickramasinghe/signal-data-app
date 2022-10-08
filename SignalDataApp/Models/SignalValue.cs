using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalDataApp.Models
{
    public class SignalValue
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int SignalId { get; set; }
        public decimal Value { get; set; }
        public DateTime DataUtc { get; set; }
        public DateTime ReadUtc { get; set; }

        public Building Building { get; set; }
        public Signal Signal { get; set; }
    }
}
