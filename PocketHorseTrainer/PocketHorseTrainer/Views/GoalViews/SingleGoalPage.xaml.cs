using PocketHorseTrainer.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleGoalPage : ContentPage
    {
        public SingleGoalPage()
        {
            InitializeComponent();
        }

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var goal = (Goal)BindingContext;
            await Navigation.PushAsync(new EditGoalPage(goal));
        }
    }
}