using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = new DateTime().Date;
            }
        }

        private DateTime time;
        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                //figure out how to just get the time from this class, or conjoin it into one property
                time = new DateTime();
            }
        }

        public enum Type
        {
            Farrier,
            Vet
        }

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
                DateTime newAppDate = Date.AddDays(NumOfWeeks * 7);
                return newAppDate;
            }
            return Date;
        }

        //include here or in separate controller?:
        //TODO: write function to remind user of next appointment
        //TODO: write function to allow user to schedule/revise new appointments
    }
}
