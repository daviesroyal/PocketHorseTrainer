using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class AddHorseViewModel : BaseViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public AddHorseViewModel()
        {
            AddCommand = new Command(() => Add());
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }

        public ICommand AddCommand { get; set; }

        private async void Add()
        {
            var markings = new Markings
            {
                FaceMarking = FaceMarking,
                FrontLeft = FrontLeft,
                FrontRight = FrontRight,
                BackLeft = BackLeft,
                BackRight = BackRight
            };

            await apiServices.CreateMarkingsAsync(markings).ConfigureAwait(false);

            var horse = new Horse
            {
                Name = Name,
                Age = Age,
                Barn = SelectedBarn,
                Breed = SelectedBreed,
                Color = SelectedColor,
                Markings = markings
            };

            var result = await apiServices.AddHorse(horse).ConfigureAwait(false);

            if (result)
            {
                _routingService.GoTo(new HorseListPage($"{Name} has been added to your barn!"));
            }
            else
            {
                _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
            }
        }

        private List<Barn> _barns;
        private List<Breed> _breeds;
        private List<CoatColor> _colors;
        private List<FaceMarking> _faceMarkings;
        private List<LegMarking> _legMarkings;

        private Barn _selectedBarn;
        private Breed _selectedBreed;
        private CoatColor _selectedColor;
        private FaceMarking _faceMarking;
        private LegMarking _frontLeft;
        private LegMarking _frontRight;
        private LegMarking _backLeft;
        private LegMarking _backRight;

        public List<Barn> Barns
        {
            get
            {
                return _barns;
            }
            set
            {
                _barns = new List<Barn>(apiServices.GetBarns().Result);
            }
        }
        public Barn SelectedBarn
        {
            get
            {
                return _selectedBarn;
            }
            set
            {
                _selectedBarn = value;
                OnPropertyChanged();
            }
        }

        public List<Breed> Breeds
        {
            get
            {
                return _breeds;
            }
            set
            {
                _breeds = new List<Breed>(apiServices.GetBreeds().Result);
            }
        }
        public Breed SelectedBreed
        {
            get
            {
                return _selectedBreed;
            }
            set
            {
                _selectedBreed = value;
                OnPropertyChanged();
            }
        }

        public List<CoatColor> Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = new List<CoatColor>(apiServices.GetColors().Result);
            }
        }
        public CoatColor SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        public List<FaceMarking> FaceMarkings
        {
            get
            {
                return _faceMarkings;
            }
            set
            {
                _faceMarkings = new List<FaceMarking>(apiServices.GetFaceMarkings().Result);
            }
        }
        public FaceMarking FaceMarking
        {
            get
            {
                return _faceMarking;
            }
            set
            {
                _faceMarking = value;
                OnPropertyChanged();
            }
        }

        public List<LegMarking> LegMarkings
        {
            get
            {
                return _legMarkings;
            }
            set
            {
                _legMarkings = new List<LegMarking>(apiServices.GetLegMarkings().Result);
            }
        }
        public LegMarking FrontLeft
        {
            get
            {
                return _frontLeft;
            }
            set
            {
                _frontLeft = value;
                OnPropertyChanged();
            }
        }
        public LegMarking FrontRight
        {
            get
            {
                return _frontRight;
            }
            set
            {
                _frontRight = value;
                OnPropertyChanged();
            }
        }
        public LegMarking BackLeft
        {
            get
            {
                return _backLeft;
            }
            set
            {
                _backLeft = value;
                OnPropertyChanged();
            }
        }
        public LegMarking BackRight
        {
            get
            {
                return _backRight;
            }
            set
            {
                _backRight = value;
                OnPropertyChanged();
            }
        }
    }
}
