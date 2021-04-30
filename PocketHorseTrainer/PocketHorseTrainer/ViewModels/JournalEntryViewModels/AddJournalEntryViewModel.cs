using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Enums;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class AddJournalEntryViewModel : BaseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

        public AddJournalEntryViewModel()
        {
            AddCommand = new Command(() => Add());
            Areas = apiServices.GetAreas().Result;
        }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public Discipline Discipline { get; set; }
        public Weather Weather { get; set; }
        public string Location { get; set; }
        public List<TargetAreas> Issues { get; set; }
        public List<TargetAreas> Strengths { get; set; }

        public ICommand AddCommand { get; set; }

        private void Add()
        {
            Weather weather = new Weather
            {
                TempF = Weather.TempF,
                Precipitation = SelectedPrecipitation,
                Wind = SelectedWind,
                CloudCover = SelectedCloudCover,
                Visibility = SelectedVisibility,
                GroundCondition = SelectedGroundContiton
            };
            _ = apiServices.CreateWeatherAsync(weather);
            JournalEntry entry = new JournalEntry
            {
                Date = Date,
                TimeHandling = TimeHandling,
                TimeRiding = TimeRiding,
                Discipline = SelectedDiscipline,
                Weather = weather,
                Location = Location,
                Issues = SelectedIssues,
                Strengths = SelectedStrengths
            };

            _ = apiServices.AddJournalEntry(entry.Horse.Id, entry);
        }

        #region enums
        private Discipline _selectedDiscipline;
        public Discipline SelectedDiscipline
        {
            get
            {
                return _selectedDiscipline;
            }
            set
            {
                if (_selectedDiscipline != value)
                {
                    _selectedDiscipline = value;
                    OnPropertyChanged();
                }
            }
        }

        private Precipitation _selectedPrecipitation;
        public Precipitation SelectedPrecipitation
        {
            get
            {
                return _selectedPrecipitation;
            }
            set
            {
                if (_selectedPrecipitation != value)
                {
                    _selectedPrecipitation = value;
                    OnPropertyChanged();
                }
            }
        }

        private Wind _selectedWind;
        public Wind SelectedWind
        {
            get
            {
                return _selectedWind;
            }
            set
            {
                if (_selectedWind != value)
                {
                    _selectedWind = value;
                    OnPropertyChanged();
                }
            }
        }

        private CloudCover _selectedCloudCover;
        public CloudCover SelectedCloudCover
        {
            get
            {
                return _selectedCloudCover;
            }
            set
            {
                if (_selectedCloudCover != value)
                {
                    _selectedCloudCover = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility _selectedVisibility;
        public Visibility SelectedVisibility
        {
            get
            {
                return _selectedVisibility;
            }
            set
            {
                if (_selectedVisibility != value)
                {
                    _selectedVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private GroundCondition _selectedGroundContiton;
        public GroundCondition SelectedGroundContiton
        {
            get
            {
                return _selectedGroundContiton;
            }
            set
            {
                if (_selectedGroundContiton != value)
                {
                    _selectedGroundContiton = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public List<TargetAreas> Areas { get; set; }

        private TargetAreas selectedArea;
        public TargetAreas SelectedArea
        {
            get
            {
                return selectedArea;
            }
            set
            {
                if (selectedArea != value)
                {
                    selectedArea = value;
                }
            }
        }

        private List<TargetAreas> selectedIssues;
        public List<TargetAreas> SelectedIssues
        {
            get
            {
                return selectedIssues;
            }
            set
            {
                if (selectedIssues != value)
                {
                    selectedIssues = value;
                }
            }
        }

        private List<TargetAreas> selectedStrengths;
        public List<TargetAreas> SelectedStrengths
        {
            get
            {
                return selectedStrengths;
            }
            set
            {
                if (selectedStrengths != value)
                {
                    selectedStrengths = value;
                }
            }
        }
    }
}
