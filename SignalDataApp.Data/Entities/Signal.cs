using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignalDataApp.Data.Entities
{
    public class Signal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string Name { get; set; }

        [ForeignKey("BuildingId")]
        public Building Building { get; set; }

        public List<SignalValue> SignalValues { get; set; }
    }
}
