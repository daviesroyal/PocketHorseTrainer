using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class AddJournalEntryViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices apiServices = new ApiServices();

        public DateTime Date { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public Discipline Discipline { get; set; }
        public Weather Weather { get; set; }
        public string Location { get; set; }
        public List<TargetAreas> Issues { get; set; }
        public List<TargetAreas> Strengths { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    JournalEntry entry = new JournalEntry
                    {
                        Date = Date,
                        TimeHandling = TimeHandling,
                        TimeRiding = TimeRiding,
                        Discipline = Discipline,
                        Weather = Weather,
                        Location = Location,
                        Issues = Issues,
                        Strengths = Strengths
                    };

                    await apiServices.AddJournalEntry(entry.Horse.Id, entry).ConfigureAwait(false);
                });
            }
        }

        private TargetAreas selectedArea;
        private int selectedCount = 0;

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

        public ObservableCollection<TargetAreas> TargetAreas { get; }

        private ObservableCollection<TargetAreas> selectedIssues;
        public ObservableCollection<TargetAreas> SelectedIssues
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

        private ObservableCollection<TargetAreas> selectedStrengths;
        public ObservableCollection<TargetAreas> SelectedStrengths
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

        public string SelectedIssueMessage { get; private set; }
        public string SelectedStrengthMessage { get; private set; }
        public ICommand IssueSelectionChangedCommand => new Command(IssueSelectionChanged);
        public ICommand StrengthSelectionChangedCommand => new Command(StrengthSelectionChanged);

        private void IssueSelectionChanged()
        {
            SelectedIssueMessage = $"Selection {selectedCount}: {SelectedArea.Name}";
            OnPropertyChanged("SelectedIssueMessage");
            selectedCount++;
        }

        private void StrengthSelectionChanged()
        {
            SelectedStrengthMessage = $"Selection {selectedCount}: {SelectedArea.Name}";
            OnPropertyChanged("SelectedStrengthMessage");
            selectedCount++;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
