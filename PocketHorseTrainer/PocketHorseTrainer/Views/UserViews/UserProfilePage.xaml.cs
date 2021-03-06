using PocketHorseTrainer.ViewModels;
using Splat;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();

            BindingContext = new UserProfileViewModel();
        }

        private async void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ChangePasswordPage()).ConfigureAwait(false);
        }

        private async void OnUpdateContactButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ChangePhoneAndEmailPage()).ConfigureAwait(false);
        }
    }
}