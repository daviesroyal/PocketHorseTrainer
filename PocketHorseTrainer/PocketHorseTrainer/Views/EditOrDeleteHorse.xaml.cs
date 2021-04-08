using PocketHorseTrainer.Models;
using PocketHorseTrainer.ViewModels;
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
    public partial class EditOrDeleteHorse : ContentPage
    {
        public EditOrDeleteHorse(Horse horse)
        {
            InitializeComponent();

            var editHorseViewModel = new EditHorseViewModel
            {
                Horse = horse
            };

            BindingContext = editHorseViewModel;
        }
    }
}