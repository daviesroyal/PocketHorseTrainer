using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class HorseProfileViewModel
    {
        readonly ApiServices apiServices = new ApiServices();
        readonly string accessToken = AccessTokenSettings.AccessToken;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }
        public Markings Markings { get; set; }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await apiServices.DeleteHorse(Id, accessToken);
                });
            }
        }
    }
}
