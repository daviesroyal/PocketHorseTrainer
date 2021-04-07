using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public enum Type
    {
        Farrier,
        Vet
    }

    public class Appointment
    {
        public int Id { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public Type Type { get; set; }

        public bool Recurring { get; set; }

        public int NumOfWeeks { get; set; }

        private DateTime nextAppDate;
        public DateTime NextAppDate
        {
            get
            {
                return nextAppDate;
            }
            set
            {
                nextAppDate = CalculateNextAppDate(Recurring, NumOfWeeks);
            }
        }

        public Appointment()
        {
        }

        //function for calculating recurring appointment dates - include new time or allow revisions?
        public DateTime CalculateNextAppDate(bool recurring = false, int numOfWeeks = 0)
        {
            Recurring = recurring;
            NumOfWeeks = numOfWeeks;

            if (Recurring == true)
            {
                DateTime newAppDate = AppointmentDateTime.AddDays(NumOfWeeks * 7);
                return newAppDate;
            }
            return AppointmentDateTime;
        }

        //include here or in separate controller?:
        //TODO: write function to remind user of next appointment
        //TODO: write function to allow user to schedule/revise new appointments
    }
}
