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
        private readonly static ApiServices apiServices = new ApiServices();
        private readonly static string AccessToken = AccessTokenSettings.AccessToken;

        public string Name { get; set; }
        public int Age { get; set; }

        //TODO: fix picker source
        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }
        public Markings Markings { get; set; }

        private static readonly List<Barn> barns = apiServices.GetBarns(AccessToken).Result;
        private static readonly List<Breed> breeds = apiServices.GetBreeds(AccessToken).Result;
        private static readonly List<CoatColor> colors = apiServices.GetColors(AccessToken).Result;
        private static readonly List<FaceMarking> faceMarkings = apiServices.GetFaceMarkings(AccessToken).Result;
        private static readonly List<LegMarking> legMarkings = apiServices.GetLegMarkings(AccessToken).Result;

        public ObservableCollection<Barn> Barns { get; set; } = new ObservableCollection<Barn>(barns);
        public ObservableCollection<Breed> Breeds { get; set; } = new ObservableCollection<Breed>(breeds);
        public ObservableCollection<CoatColor> Colors { get; set; } = new ObservableCollection<CoatColor>(colors);
        public ObservableCollection<FaceMarking> FaceMarkings { get; set; } = new ObservableCollection<FaceMarking>(faceMarkings);
        public ObservableCollection<LegMarking> LegMarkings { get; set; } = new ObservableCollection<LegMarking>(legMarkings);

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
                    await apiServices.AddHorse(horse, AccessTokenSettings.AccessToken).ConfigureAwait(false);
                });
            }
        }
    }
}
