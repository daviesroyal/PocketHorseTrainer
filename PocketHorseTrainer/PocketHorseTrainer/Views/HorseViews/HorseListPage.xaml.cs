using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
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
    public partial class HorseListPage : ContentPage
    {
        readonly ApiServices apiServices = new ApiServices();

        public HorseListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await apiServices.GetAllHorses(AccessTokenSettings.AccessToken);
        }

        async void OnAddHorseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddHorsePage());
        }

        async void OnHorseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new HorsePage
            {
                BindingContext = e.SelectedItem as Horse
            });
        }
    }
}