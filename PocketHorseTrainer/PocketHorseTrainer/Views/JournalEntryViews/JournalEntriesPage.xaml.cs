using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JournalEntriesPage : ContentPage
    {
        private readonly ApiServices apiServices = new ApiServices();

        public JournalEntriesPage() => InitializeComponent();

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            _ = await apiServices.GetAllJournalEntries(((JournalEntry)BindingContext).Horse.Id).ConfigureAwait(false);
        }

        private async void OnAddEntryClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddJournalEntryPage()).ConfigureAwait(false);
        }

        private async void OnEntrySelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new JournalEntryPage { BindingContext = e.SelectedItem as JournalEntry }).ConfigureAwait(false);
        }
    }
}