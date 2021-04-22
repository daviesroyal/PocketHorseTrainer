using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalListPage : ContentPage
    {
        private readonly ApiServices apiServices = new ApiServices();

        public GoalListPage() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await apiServices.GetAllGoals(AccessTokenSettings.AccessToken, ((Goal)BindingContext).Horse.Id).ConfigureAwait(false);
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