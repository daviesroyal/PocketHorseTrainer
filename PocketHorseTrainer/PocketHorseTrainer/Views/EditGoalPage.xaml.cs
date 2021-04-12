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
    public partial class EditGoalPage : ContentPage
    {
        public EditGoalPage(Goal goal)
        {
            InitializeComponent();

            var editGoalViewModel = new EditGoalViewModel
            {
                Goal = goal
            };

            BindingContext = editGoalViewModel;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Goal goal = (Goal)BindingContext;
            goal.Completed = e.Value;
        }

    }
}