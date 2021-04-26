﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePhoneAndEmailPage : ContentPage
    {
        public ChangePhoneAndEmailPage() => InitializeComponent();

        protected override bool OnBackButtonPressed() => true;

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync("//profile");
        }
    }
}