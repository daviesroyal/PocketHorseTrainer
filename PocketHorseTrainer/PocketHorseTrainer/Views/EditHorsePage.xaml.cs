﻿using PocketHorseTrainer.Models;
using PocketHorseTrainer.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketHorseTrainer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditHorsePage : ContentPage
    {
        public EditHorsePage(Horse horse)
        {
            InitializeComponent();

            var editHorseViewModel = new EditHorseViewModel
            {
                Horse = horse
            };

            BindingContext = editHorseViewModel;
        }
    }
}