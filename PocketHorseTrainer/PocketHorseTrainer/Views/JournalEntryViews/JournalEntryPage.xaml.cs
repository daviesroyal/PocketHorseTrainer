using PocketHorseTrainer.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JournalEntryPage : ContentPage
    {
        public JournalEntryPage() => InitializeComponent();

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new EditJournalEntryPage((JournalEntry)BindingContext)).ConfigureAwait(false);
        }
    }
}