using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalListPage : ContentPage
    {
        public GoalListPage(Horse horse)
        {
            InitializeComponent();

            Horse = horse;

            BindingContext = new GoalListViewModel(Horse);
        }

        private static Horse Horse { get; set; }

        private async void OnAddGoalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage(Horse)).ConfigureAwait(false);
        }

        private async void OnGoalSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SingleGoalPage((Goal)e.SelectedItem)).ConfigureAwait(false);
        }
    }
}