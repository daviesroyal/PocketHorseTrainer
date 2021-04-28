using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditHorseViewModel : BaseViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public Horse Horse { get; set; }

        public EditHorseViewModel(Horse horse)
        {
            Horse = horse;

            EditCommand = new Command(() => Edit());
        }

        public EditHorseViewModel()
        {
            EditCommand = new Command(() => Edit());
        }

        public ICommand EditCommand { get; set; }

        private async void Edit()
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

            Horse.Name = Horse.Name;
            Horse.Age = Horse.Age;
            Horse.Barn = SelectedBarn;
            Horse.Breed = SelectedBreed;
            Horse.Color = SelectedColor;
            Horse.Markings = markings;

            var result = await apiServices.EditHorse(Horse).ConfigureAwait(false);

            if (result)
            {
                _routingService.GoTo(new HorseListPage($"{Horse.Name}'s info has been updated!"));
            }
            else
            {
                _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
            }
        }

        private List<Barn> _barns = apiServices.GetBarns().Result;
        private List<Breed> _breeds = apiServices.GetBreeds().Result;
        private List<CoatColor> _colors = apiServices.GetColors().Result;
        private List<FaceMarking> _faceMarkings = apiServices.GetFaceMarkings().Result;
        private List<LegMarking> _legMarkings = apiServices.GetLegMarkings().Result;

        //TODO: persist current data to form fields
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
                if (_barns != value)
                {
                    _barns = value;
                    OnPropertyChanged();
                }
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
                if (_selectedBarn != value)
                {
                    _selectedBarn = value;
                    OnPropertyChanged();
                }
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
                if (_breeds != value)
                {
                    _breeds = value;
                    OnPropertyChanged();
                }
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
                if (_selectedBreed != value)
                {
                    _selectedBreed = value;
                    OnPropertyChanged();
                }
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
                if (_colors != value)
                {
                    _colors = value;
                    OnPropertyChanged();
                }
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
                if (_selectedColor != value)
                {
                    _selectedColor = value;
                    OnPropertyChanged();
                }
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
                if (_faceMarkings != value)
                {
                    _faceMarkings = value;
                    OnPropertyChanged();
                }
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
                if (_faceMarking != value)
                {
                    _faceMarking = value;
                    OnPropertyChanged();
                }
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
                if (_legMarkings != value)
                {
                    _legMarkings = value;
                    OnPropertyChanged();
                }
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
                if (_frontLeft != value)
                {
                    _frontLeft = value;
                    OnPropertyChanged();
                }
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
                if (_frontRight != value)
                {
                    _frontRight = value;
                    OnPropertyChanged();
                }
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
                if (_backLeft != value)
                {
                    _backLeft = value;
                    OnPropertyChanged();
                }
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
                if (_backRight != value)
                {
                    _backRight = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
