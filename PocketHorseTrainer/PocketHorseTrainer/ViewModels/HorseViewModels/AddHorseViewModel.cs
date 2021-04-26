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

        public string Name { get; set; }
        public int Age { get; set; }

        public Barn Barn { get; set; }
        public Breed Breed { get; set; }
        public CoatColor Color { get; set; }

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
                        Barn = SelectedBarn,
                        Breed = SelectedBreed,
                        Color = SelectedColor,
                        Markings = new Markings
                        {
                            FaceMarking = FaceMarking,
                            FrontLeft = FrontLeft,
                            FrontRight = FrontRight,
                            BackLeft = BackLeft,
                            BackRight = BackRight
                        }
                    };

                    var result = await apiServices.AddHorse(horse).ConfigureAwait(false);

                    if (result)
                    {
                        //navigation is once again going weird, and messes up other navigation if I try to back out.
                        _ = Task.Run(async () => await Shell.Current.Navigation.PushAsync(new HorseListPage($"{Name} has been added to your barn!")).ConfigureAwait(false));
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

        private Barn _selectedBarn;
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

        private Breed _selectedBreed;
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

        private CoatColor _selectedColor;
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

        private FaceMarking _faceMarking;
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

        private LegMarking _frontLeft;
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

        private LegMarking _frontRight;
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

        private LegMarking _backLeft;
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

        private LegMarking _backRight;
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
