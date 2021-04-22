using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditJournalEntryViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices apiServices = new ApiServices();

        public JournalEntry Entry { get; set; }

        private readonly string accessToken = AccessTokenSettings.AccessToken;

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () => await apiServices.EditJournalEntry(accessToken, Entry).ConfigureAwait(false));
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
