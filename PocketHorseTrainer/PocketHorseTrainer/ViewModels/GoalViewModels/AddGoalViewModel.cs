using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class AddGoalViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

        public string Name { get; set; }
        public TimeLength TimeSpan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TargetAreas AreaOfImprovement { get; set; }
        public bool Completed { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var goal = new Goal
                    {
                        Name = Name,
                        TimeSpan = (Models.TimeLength)TimeSpan,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        AreaOfImprovement = AreaOfImprovement,
                        Completed = false
                    };

                    await apiServices.AddGoal(goal.Horse.Id, goal).ConfigureAwait(false);
                });
            }
        }
    }
}
