using PocketHorseTrainer.ViewModels;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();

            BindingContext = new ChangePasswordViewModel();
        }

        protected override bool OnBackButtonPressed() => true;

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//profile").ConfigureAwait(false);
        }
    }
}