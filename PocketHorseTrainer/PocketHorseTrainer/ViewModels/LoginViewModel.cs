using PocketHorseTrainer.Services;
using PocketHorseTrainer.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiServices _apiConnector = new ApiServices();

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiConnector.LoginAsync(UserName, Password, RememberMe);

                    AccessTokenSettings.AccessToken = accesstoken;
                });
            }
        }

    }
}
