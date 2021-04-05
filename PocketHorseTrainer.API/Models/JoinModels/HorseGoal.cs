using Microsoft.EntityFrameworkCore;

namespace PocketHorseTrainer.API.Models
{
    public class HorseGoal
    {
        public DbSet<HorseGoal> HorseGoals { get; set; }

        public int HorseId { get; set; }
        public Horse Horse { get; set; }

        public int GoalId { get; set; }
        public Goal Goal { get; set; }

        public HorseGoal()
        {

        }
    }
}
