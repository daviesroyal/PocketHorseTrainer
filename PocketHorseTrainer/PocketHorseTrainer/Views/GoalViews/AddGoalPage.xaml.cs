using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGoalPage : ContentPage
    {
        public AddGoalPage() => InitializeComponent();

        protected override bool OnBackButtonPressed() => true;
    }
}