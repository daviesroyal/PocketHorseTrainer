using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage() => InitializeComponent();

        protected override bool OnBackButtonPressed() => true;

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//profile");
        }
    }
}