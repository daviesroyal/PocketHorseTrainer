using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.ViewModels.GoalViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalListPage : ContentPage
    {
        public GoalListPage()
        {
            InitializeComponent();

            BindingContext = new GoalListViewModel();
        }
        public GoalListPage(Horse horse)
        {
            InitializeComponent();

            BindingContext = new GoalListViewModel(horse);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() => listView.ItemsSource = new GoalListViewModel().Goals);
        }

        private async void OnAddGoalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage()).ConfigureAwait(false);
        }

        private async void OnGoalSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SingleGoalPage
            {
                BindingContext = (Goal)e.SelectedItem
            }).ConfigureAwait(false);
        }
    }
}