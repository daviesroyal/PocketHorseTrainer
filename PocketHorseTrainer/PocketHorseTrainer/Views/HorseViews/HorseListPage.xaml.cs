using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.ViewModels;
using PocketHorseTrainer.ViewModels.HorseViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorseListPage : ContentPage
    {
        public HorseListPage()
        {
            InitializeComponent();

            BindingContext = new HorseListViewModel();
        }

        public HorseListPage(string message)
        {
            InitializeComponent();

            BindingContext = new HorseListViewModel
            {
                Message = message
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() => listView.ItemsSource = new HorseListViewModel().Horses);
        }

        private async void OnAddHorseClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new AddHorsePage()).ConfigureAwait(false);
        }

        private async void OnHorseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new HorsePage((Horse)e.SelectedItem)).ConfigureAwait(false);
        }
    }
}