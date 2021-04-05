using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class HorseOwner
    {
        public DbSet<HorseOwner> HorseOwners { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }

        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public HorseOwner()
        {

        }
    }
}
