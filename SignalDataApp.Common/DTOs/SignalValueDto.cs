using System;
using System.Collections.Generic;
using System.Text;

namespace SignalDataApp.Common.DTOs
{
    public class SignalValueDto
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int SignalId { get; set; }
        public decimal Value { get; set; }
        public DateTime DataUtc { get; set; }
        public DateTime ReadUtc { get; set; }
    }
}
