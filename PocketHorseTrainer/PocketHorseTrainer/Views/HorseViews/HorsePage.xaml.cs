using PocketHorseTrainer.Models;
using PocketHorseTrainer.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HorsePage : ContentPage
    {
        public HorsePage(Horse horse)
        {
            InitializeComponent();

            BindingContext = new HorseProfileViewModel(horse);
        }
    }
}