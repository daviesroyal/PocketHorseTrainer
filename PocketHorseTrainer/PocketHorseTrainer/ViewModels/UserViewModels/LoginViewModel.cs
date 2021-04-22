using PocketHorseTrainer.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

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
                    var result = await apiServices.LoginAsync(UserName, Password, RememberMe);

                    if (result.Success == false)
                    {
                        await Application.Current.MainPage.DisplayAlert("Uh oh!", result.Message, "OK");
                    }
                    else
                    {
                        AccessTokenSettings.AccessToken = result.Message;
                        Application.Current.Properties["accessToken"] = AccessTokenSettings.AccessToken;
                        await Application.Current.SavePropertiesAsync();
                        await Shell.Current.GoToAsync("//main/home");
                    }
                });
            }
        }

        public ICommand TapCommand
        {
            get
            {
                return new Command(async () =>
                {
                    string email = await Application.Current.MainPage.DisplayPromptAsync("Forgot Password", "Enter your email:");
                    if (email != null)
                    {
                        var result = await apiServices.ForgotPasswordAsync(email);
                        if (result)
                        {
                            await Application.Current.MainPage.DisplayAlert("Success", "A link to reset your password has been sent to your email.", "OK");
                        }
                        else
                        {
                            await Shell.Current.GoToAsync("//login");
                        }
                    }
                });
            }
        }
    }
}
