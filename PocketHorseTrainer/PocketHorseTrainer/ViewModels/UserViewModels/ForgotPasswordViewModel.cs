using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class ForgotPasswordViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public ForgotPasswordViewModel()
        {
            ResetCommand = new Command(() => Reset());
        }

        public string Email { get; set; }
        public ICommand ResetCommand { get; set; }

        public async void Reset()
        {
            var result = await apiServices.ForgotPasswordAsync(Email).ConfigureAwait(false);

            if (result)
            {
                _messageService.DisplayAlert(title: "Success!", message: $"A link to reset your password has been sent to {Email}");
                _routingService.NavigateTo("//login");
            }
            else
            {
                _routingService.NavigateTo("//login");
            }
        }
    }
}
