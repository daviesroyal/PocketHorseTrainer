using PocketHorseTrainer.Services;
using PocketHorseTrainer.ViewModels;
using PocketHorseTrainer.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer
{
    public partial class AppShell : Shell
    {
        readonly ApiServices apiServices = new ApiServices();

        public AppShell()
        {
            InitializeComponent();

            BindingContext = this;
        }

        public ICommand ExecuteLogout
        {
            get
            {
                return new Command(async () => 
                {
                    await apiServices.Logout(AccessTokenSettings.AccessToken);
                    await Current.GoToAsync("//login");
                });
            }
        }
    }
}
