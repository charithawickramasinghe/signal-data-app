using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignalDataApp.Data.Entities
{
    public class SignalValue
    {
        [Key]
        public int SignalValuelId { get; set; }
        public int Id { get; set; }
        public int SignalId { get; set; }
        public decimal Value { get; set; }
        public DateTime DataUtc { get; set; }
        public DateTime ReadUtc { get; set; }

        [ForeignKey("SignalId")]
        public Signal Signal{ get; set; }



    }
}
