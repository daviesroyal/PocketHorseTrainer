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

            var horse = new Horse
            {
                Name = Horse.Name,
                Age = Horse.Age,
                Barn = SelectedBarn,
                Breed = SelectedBreed,
                Color = SelectedColor,
                Markings = markings
            };

            var result = await apiServices.EditHorse(horse).ConfigureAwait(false);

            if (result)
            {
                _routingService.GoTo(new HorseListPage($"{Horse.Name}'s info has been updated!"));
            }
            else
            {
                _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
            }
        }

        public void Init()
        {
            _selectedBarn = Horse.Barn;
            _selectedBreed = Horse.Breed;
            _selectedColor = Horse.Color;
            _faceMarking = Horse.Markings.FaceMarking;
            _frontLeft = Horse.Markings.FrontLeft;
            _frontRight = Horse.Markings.FrontRight;
            _backLeft = Horse.Markings.BackLeft;
            _backRight = Horse.Markings.BackRight;
        }

        private Barn _selectedBarn;
        private Breed _selectedBreed;
        private CoatColor _selectedColor;
        private FaceMarking _faceMarking;
        private LegMarking _frontLeft;
        private LegMarking _frontRight;
        private LegMarking _backLeft;
        private LegMarking _backRight;

        public IList<Barn> Barns
        {
            get
            {
                return SupportData.Barns;
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

        public IList<Breed> Breeds
        {
            get
            {
                return SupportData.Breeds;
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

        public IList<CoatColor> Colors
        {
            get
            {
                return SupportData.Colors;
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

        public IList<FaceMarking> FaceMarkings
        {
            get
            {
                return SupportData.FaceMarkings;
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

        public IList<LegMarking> LegMarkings
        {
            get
            {
                return SupportData.LegMarkings;
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
