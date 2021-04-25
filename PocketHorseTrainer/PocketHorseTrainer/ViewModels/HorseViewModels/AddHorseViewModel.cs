using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
using PocketHorseTrainer.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class AddHorseViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();

        public string Name { get; set; }
        public int Age { get; set; }

        //TODO: fix picker source
        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }
        public Markings Markings { get; set; }

        public IList<Barn> Barns = apiServices.GetBarns().Result;
        public IList<Breed> Breeds = apiServices.GetBreeds().Result;
        public IList<CoatColor> Colors = apiServices.GetColors().Result;
        public IList<FaceMarking> FaceMarkings = apiServices.GetFaceMarkings().Result;
        public IList<LegMarking> LegMarkings = apiServices.GetLegMarkings().Result;

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
                    await apiServices.AddHorse(horse).ConfigureAwait(false);
                });
            }
        }
    }
}
