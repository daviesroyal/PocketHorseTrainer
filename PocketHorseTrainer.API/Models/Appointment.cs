using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Appointment
    {
        public DateTime DateTime { get; set; }
        public enum Type
        {
            Farrier,
            Vet
        }
        public bool Recurring { get; set; }
        public int NumOfWeeks { get; set; }

        public Appointment()
        {

        }
    }
}
