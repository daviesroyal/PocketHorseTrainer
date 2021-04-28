using PocketHorseTrainer.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public LoginViewModel()
        {
            LoginCommand = new Command(() => Login());
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string Message { get; set; }
        public ICommand LoginCommand { get; set; }

        private async void Login()
        {
            var result = await apiServices.LoginAsync(UserName, Password, RememberMe).ConfigureAwait(false);

            if (!result)
            {
                Message = "Something went wrong. Check your credentials and make sure your email is verified.";
                _messageService.DisplayAlert("Uh oh!", Message);
            }
            else
            {
                _routingService.NavigateTo("//main");
            }
        }
    }
}
