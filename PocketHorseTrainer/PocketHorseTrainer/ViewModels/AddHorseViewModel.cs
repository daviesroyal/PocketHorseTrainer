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
    public class AddHorseViewModel
    {
        readonly ApiServices apiServices = new ApiServices();
        public string Name { get; set; }
        public int Age { get; set; }
        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }
        public Markings Markings { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var horse = new Horse
                    {
                        Name = Name,
                        Age = Age,
                        Barn = Barn,
                        Breed = Breed,
                        Color = Color,
                        Markings = Markings
                    };
                    await apiServices.AddHorse(horse, AccessTokenSettings.AccessToken);
                });
            }
        }

    }
}
