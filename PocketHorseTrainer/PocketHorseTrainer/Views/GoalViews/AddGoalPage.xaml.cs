using PocketHorseTrainer.Models;
using PocketHorseTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGoalPage : ContentPage
    {
        public AddGoalPage(Horse horse)
        {
            InitializeComponent();

            BindingContext = new AddGoalViewModel(horse);
        }
    }
}