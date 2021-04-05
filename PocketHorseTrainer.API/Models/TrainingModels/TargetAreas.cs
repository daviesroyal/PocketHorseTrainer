using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    //future: allow trainers/admins only to edit list
    public class TargetAreas
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public TargetAreas()
        {

        }
    }
}
