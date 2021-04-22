using PocketHorseTrainer.Models.Training;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddJournalEntryPage : ContentPage
    {
        public AddJournalEntryPage() => InitializeComponent();

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        private void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            previousSelectedItemLabel.Text = string.IsNullOrWhiteSpace(ToList(previousSelectedItems)) ? "[none]" : ToList(previousSelectedItems);
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(ToList(currentSelectedItems)) ? "[none]" : ToList(currentSelectedItems);
        }

        private static string ToList(IEnumerable<object> items)
        {
            return items == null
                ? string.Empty
                : items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((TargetAreas)obj).Name);
        }
    }
}