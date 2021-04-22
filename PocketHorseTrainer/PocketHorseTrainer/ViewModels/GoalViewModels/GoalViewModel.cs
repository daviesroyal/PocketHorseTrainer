using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public enum TimeLength
    {
        daily,
        weekly,
        monthly,
        yearly
    }

    public class GoalViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

        public int Id { get; set; }
        public string Name { get; set; }
        public Horse Horse { get; set; }
        public TimeLength TimeSpan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public TargetAreas AreaOfImprovement { get; set; }
        public bool Completed { get; set; }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () => await apiServices.DeleteGoal(Id, AccessTokenSettings.AccessToken).ConfigureAwait(false));
            }
        }
    }
}
