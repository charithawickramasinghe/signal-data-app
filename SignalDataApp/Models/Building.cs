using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalDataApp.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SignalValue> SignalValues { get; set; }
    }
}
