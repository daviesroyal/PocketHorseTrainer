﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage() => InitializeComponent();

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage()).ConfigureAwait(false);
        }
    }
}