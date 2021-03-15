using PocketHorseTrainer.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PocketHorseTrainer.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}