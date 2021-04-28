using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
using PocketHorseTrainer.Services;
using PocketHorseTrainer.ViewModels;
using System.Collections.Generic;
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

            Horse = horse;

            BindingContext = new EditHorseViewModel(Horse);
        }

        internal static Horse Horse { get; set; }

        protected override bool OnBackButtonPressed() => true;

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//horses");
        }
    }
}