using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditJournalEntryViewModel : BaseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

        public EditJournalEntryViewModel()
        {
            EditCommand = new Command(() => Edit());
        }
        public JournalEntry Entry { get; set; }

        public ICommand EditCommand { get; set; }

        private Task Edit()
        {
            return apiServices.EditJournalEntry(Entry);
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
    }
}
