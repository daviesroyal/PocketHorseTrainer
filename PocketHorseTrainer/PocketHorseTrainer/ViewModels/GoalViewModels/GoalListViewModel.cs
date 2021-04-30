using MvvmHelpers;
using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class GoalListViewModel : BaseViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();

        public Horse Horse { get; set; }

        public GoalListViewModel(Horse horse)
        {
            Horse = horse;
            Goals = new ObservableRangeCollection<Goal>();
            AllGoals = new ObservableRangeCollection<Goal>();
            FilterOptions = new Dictionary<string, bool?>
            {
                { "All", null },
                { "In Progress", false },
                { "Completed", true }
            };
            LoadCommand = new Command(async () => await Load().ConfigureAwait(false));
        }

        public ObservableRangeCollection<Goal> Goals { get; set; }
        public ObservableRangeCollection<Goal> AllGoals { get; set; }
        public Dictionary<string, bool?> FilterOptions { get; set; }
        private string _selectedFilter = "All";
        public string SelectedFilter
        {
            get
            {
                return _selectedFilter;
            }
            set
            {
                if (SetProperty(ref _selectedFilter, value))
                {
                    FilterGoals();
                }
            }
        }
        private void FilterGoals()
        {
            Goals.ReplaceRange(AllGoals.Where(g => g.Completed == FilterOptions[SelectedFilter] || SelectedFilter == "All"));
        }
        public ICommand LoadCommand { get; set; }
        private async Task Load()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                var goals = await apiServices.GetAllGoals(Horse.Id).ConfigureAwait(false);
                AllGoals.ReplaceRange(goals);
                FilterGoals();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
