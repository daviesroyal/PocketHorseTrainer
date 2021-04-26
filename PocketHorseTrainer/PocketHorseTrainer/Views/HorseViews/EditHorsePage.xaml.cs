using PocketHorseTrainer.Models;
using PocketHorseTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditHorsePage : ContentPage
    {
        public EditHorsePage(Horse horse)
        {
            InitializeComponent();

            BindingContext = new EditHorseViewModel(horse);
        }

        protected override bool OnBackButtonPressed() => true;

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//horses");
        }
    }
}