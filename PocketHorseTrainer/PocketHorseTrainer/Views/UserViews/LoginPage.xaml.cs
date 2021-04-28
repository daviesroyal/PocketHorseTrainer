using PocketHorseTrainer.ViewModels;
using Splat;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new RegisterPage());
        }

        protected override bool OnBackButtonPressed() => true;

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            ((LoginViewModel)BindingContext).RememberMe = e.Value;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}