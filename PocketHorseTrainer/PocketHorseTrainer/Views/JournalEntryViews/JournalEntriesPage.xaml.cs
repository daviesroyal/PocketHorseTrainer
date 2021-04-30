using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.ViewModels.JournalEntryViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JournalEntriesPage : ContentPage
    {
        public JournalEntriesPage(Horse horse)
        {
            InitializeComponent();

            BindingContext = new JournalEntriesViewModel(horse);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() => listView.ItemsSource = ((JournalEntriesViewModel)BindingContext).Entries);
        }

        private async void OnAddEntryClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new AddJournalEntryPage()).ConfigureAwait(false);
        }

        private async void OnEntrySelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new JournalEntryPage { BindingContext = e.SelectedItem as JournalEntry }).ConfigureAwait(false);
        }
    }
}