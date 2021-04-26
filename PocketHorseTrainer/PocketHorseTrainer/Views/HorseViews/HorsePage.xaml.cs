using PocketHorseTrainer.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorsePage : ContentPage
    {
        public HorsePage() => InitializeComponent();

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new EditHorsePage((Horse)BindingContext)).ConfigureAwait(false);
        }

        private void OnGoalButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new GoalListPage());
        }

        private void OnJournalButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new JournalEntriesPage());
        }
    }
}