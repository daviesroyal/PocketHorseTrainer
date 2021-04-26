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
        public static Horse Horse { get; set; }

        public EditHorseViewModel(Horse horse)
        {
            Horse = horse;
        }

        public EditHorseViewModel()
        {
        }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
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
                        Device.BeginInvokeOnMainThread(() => Task.Run(async () => await Shell.Current.Navigation.PushAsync(new HorseListPage($"{Horse.Name}'s info has been updated!")).ConfigureAwait(false)));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Uh oh!", "Something went wrong.", "OK").ConfigureAwait(false);
                    }
                });
            }
        }

        private List<Barn> _barns = apiServices.GetBarns().Result;
        public List<Barn> Barns
        {
            get
            {
                return _barns;
            }
            private set
            {
                _barns = value;
                OnPropertyChanged();
            }
        }

        private Barn _selectedBarn = Horse.Barn;
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

        private List<Breed> _breeds = apiServices.GetBreeds().Result;
        public List<Breed> Breeds
        {
            get
            {
                return _breeds;
            }
            private set
            {
                _breeds = value;
                OnPropertyChanged();
            }
        }

        private Breed _selectedBreed = Horse.Breed;
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

        private List<CoatColor> _colors = apiServices.GetColors().Result;
        public List<CoatColor> Colors
        {
            get
            {
                return _colors;
            }
            private set
            {
                _colors = value;
                OnPropertyChanged();
            }
        }

        private CoatColor _selectedColor = Horse.Color;
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

        private List<FaceMarking> _faceMarkings = apiServices.GetFaceMarkings().Result;
        public List<FaceMarking> FaceMarkings
        {
            get
            {
                return _faceMarkings;
            }
            private set
            {
                _faceMarkings = value;
                OnPropertyChanged();
            }
        }

        private FaceMarking _faceMarking = Horse.Markings.FaceMarking;
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

        private List<LegMarking> _legMarkings = apiServices.GetLegMarkings().Result;
        public List<LegMarking> LegMarkings
        {
            get
            {
                return _legMarkings;
            }
            private set
            {
                _legMarkings = value;
                OnPropertyChanged();
            }
        }

        private LegMarking _frontLeft = Horse.Markings.FrontLeft;
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

        private LegMarking _frontRight = Horse.Markings.FrontRight;
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

        private LegMarking _backLeft = Horse.Markings.BackLeft;
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

        private LegMarking _backRight = Horse.Markings.BackRight;
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
