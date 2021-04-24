using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorseListPage : ContentPage
    {
        private readonly ApiServices apiServices = new ApiServices();

        public HorseListPage() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await apiServices.GetAllHorses().ConfigureAwait(false);
        }

        private async void OnAddHorseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHorsePage()).ConfigureAwait(false);
        }

        private async void OnHorseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new HorsePage { BindingContext = e.SelectedItem as Horse }).ConfigureAwait(false);
        }
    }
}