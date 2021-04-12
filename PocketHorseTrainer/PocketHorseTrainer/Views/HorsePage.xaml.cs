using PocketHorseTrainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorsePage : ContentPage
    {
        public HorsePage()
        {
            InitializeComponent();
        }

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var horse = (Horse)BindingContext;
            await Navigation.PushAsync(new EditHorsePage(horse));
        }

        async void OnGoalButtonClicked(object sender, EventArgs e)
        {
            var horse = (Horse)BindingContext;
            await Navigation.PushAsync(new GoalListPage(horse));
        }

        async void OnJournalButtonClicked(object sender, EventArgs e)
        {
            var horse = (Horse)BindingContext;
            await Navigation.PushAsync(new JournalEntriesPage(horse));
        }
    }
}