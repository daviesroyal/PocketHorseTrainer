using PocketHorseTrainer.Models;
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
    public partial class JournalEntryPage : ContentPage
    {
        public JournalEntryPage()
        {
            InitializeComponent();
        }

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var entry = (JournalEntry)BindingContext;
            await Navigation.PushAsync(new EditJournalEntryPage(entry));
        }
    }
}