using PocketHorseTrainer.Models.Training;
using PocketHorseTrainer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddJournalEntryPage : ContentPage
    {
        public AddJournalEntryPage()
        {
            InitializeComponent();

            BindingContext = new AddJournalEntryViewModel();
        }

        protected override bool OnBackButtonPressed() => true;

        private void Issues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Strengths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}