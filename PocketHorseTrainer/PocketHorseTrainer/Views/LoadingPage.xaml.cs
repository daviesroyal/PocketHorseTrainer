using PocketHorseTrainer.ViewModels;
using Splat;
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
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            AccessTokenSettings.AccessToken = (string)Application.Current.Properties["accessToken"];
            if (string.IsNullOrEmpty(AccessTokenSettings.AccessToken))
            {
                await Shell.Current.GoToAsync("//login");
            }
            else
            {
                await Shell.Current.GoToAsync("//main");
            }
        }
    }
}