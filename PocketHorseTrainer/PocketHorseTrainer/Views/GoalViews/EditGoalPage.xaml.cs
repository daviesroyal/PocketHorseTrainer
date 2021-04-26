using PocketHorseTrainer.Models;
using PocketHorseTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditGoalPage : ContentPage
    {
        public EditGoalPage(Goal goal)
        {
            InitializeComponent();

            BindingContext = new EditGoalViewModel
            {
                Goal = goal
            };
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ((Goal)BindingContext).Completed = e.Value;
        }

        protected override bool OnBackButtonPressed() => true;
    }
}