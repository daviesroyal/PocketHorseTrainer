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
    public partial class JournalEntriesPage : ContentPage
    {
        readonly ApiServices apiServices = new ApiServices();

        public JournalEntriesPage(Horse horse)
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var entry = (JournalEntry)BindingContext;
            var horse = entry.Horse;
            await apiServices.GetAllJournalEntries(AccessTokenSettings.AccessToken, horse.Id);
        }

        async void OnAddEntryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddJournalEntryPage());
        }

        async void OnEntrySelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new JournalEntryPage
            {
                BindingContext = e.SelectedItem as JournalEntry
            });
        }
    }
}