using PocketHorseTrainer.Models.Training;
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
    public partial class AddJournalEntryPage : ContentPage
    {
        public AddJournalEntryPage()
        {
            InitializeComponent();
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedItems, IEnumerable<object> currentSelectedItems)
        {
            var previous = ToList(previousSelectedItems);
            var current = ToList(currentSelectedItems);
            previousSelectedItemLabel.Text = string.IsNullOrWhiteSpace(previous) ? "[none]" : previous;
            currentSelectedItemLabel.Text = string.IsNullOrWhiteSpace(current) ? "[none]" : current;
        }

        static string ToList(IEnumerable<object> items)
        {
            if (items == null)
            {
                return string.Empty;
            }

            return items.Aggregate(string.Empty, (sender, obj) => sender + (sender.Length == 0 ? "" : ", ") + ((TargetAreas)obj).Name);
        }
    }
}