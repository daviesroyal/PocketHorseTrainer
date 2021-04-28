using PocketHorseTrainer.ViewModels;
using Splat;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            BindingContext = new RegisterViewModel();
        }

        protected override bool OnBackButtonPressed() => true;

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new LoginPage()).ConfigureAwait(false);
        }
    }
}