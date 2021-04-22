﻿using PocketHorseTrainer.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleGoalPage : ContentPage
    {
        public SingleGoalPage() => InitializeComponent();

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditGoalPage((Goal)BindingContext)).ConfigureAwait(false);
        }
    }
}