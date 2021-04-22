using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class JournalEntryViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }

        public Horse Horse { get; set; }

        public Discipline Discipline { get; set; }

        public Weather Weather { get; set; }

        public string Location { get; set; }

        public List<TargetAreas> Issues { get; set; }
        public List<TargetAreas> Strengths { get; set; }

        public List<Comments> Comments { get; set; }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () => await apiServices.DeleteJournalEntry(Id, AccessTokenSettings.AccessToken).ConfigureAwait(false));
            }
        }
    }
}
