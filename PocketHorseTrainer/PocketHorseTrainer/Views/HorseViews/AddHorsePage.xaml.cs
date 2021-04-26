using PocketHorseTrainer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHorsePage : ContentPage
    {
        public AddHorsePage()
        {
            InitializeComponent();

            BindingContext = new AddHorseViewModel();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//horses");
        }
    }
}