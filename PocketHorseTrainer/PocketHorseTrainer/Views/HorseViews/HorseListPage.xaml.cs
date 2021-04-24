using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using System.Threading.Tasks;
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
            _ = await Task.Run(async () => listView.ItemsSource = await apiServices.GetAllHorses().ConfigureAwait(false)).ConfigureAwait(false);
            //keep getting an AndroidRuntimeException on this page, likely to do with listView?
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