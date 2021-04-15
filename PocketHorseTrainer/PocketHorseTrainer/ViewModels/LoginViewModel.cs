using PocketHorseTrainer.Services;
using PocketHorseTrainer.Services.Routing;
using PocketHorseTrainer.Views;
using Splat;
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
        private readonly IRoutingService _navigationService;

        public LoginViewModel(IRoutingService navigationService = null)
        {
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
        }
        public LoginViewModel()
        {

        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await _apiConnector.LoginAsync(UserName, Password, RememberMe);

                    if (result.Success == false)
                    {
                        await App.Current.MainPage.DisplayAlert("Uh oh!", result.Message, "Ok");
                    }
                    else
                    {
                        AccessTokenSettings.AccessToken = result.Message;
                        await _navigationService.NavigateTo("///main/home");
                    }

                });
            }
        }

    }
}
