using PocketHorseTrainer.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await apiServices.LoginAsync(UserName, Password, RememberMe).ConfigureAwait(false);

                    if (!result.Success)
                    {
                        await Application.Current.MainPage.DisplayAlert("Uh oh!", result.Message, "OK").ConfigureAwait(false);
                    }
                    else
                    {
                        Application.Current.Properties["accessToken"] = result.Message;
                        await Application.Current.SavePropertiesAsync().ConfigureAwait(false);
                        await Shell.Current.GoToAsync("//main/home").ConfigureAwait(false);
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
                    string email = await Application.Current.MainPage.DisplayPromptAsync("Forgot Password", "Enter your email:").ConfigureAwait(false);
                    if (email != null)
                    {
                        var result = await apiServices.ForgotPasswordAsync(email).ConfigureAwait(false);
                        if (result)
                        {
                            await Application.Current.MainPage.DisplayAlert("Success", "A link to reset your password has been sent to your email.", "OK").ConfigureAwait(false);
                        }
                        else
                        {
                            await Shell.Current.GoToAsync("//login").ConfigureAwait(false);
                        }
                    }
                });
            }
        }
    }
}
