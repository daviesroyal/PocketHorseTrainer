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
        }

        private async void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage());
        }

        private async void OnUpdateContactButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePhoneAndEmailPage());
        }

        private async void OnHorsesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HorseListPage());
        }
    }
}