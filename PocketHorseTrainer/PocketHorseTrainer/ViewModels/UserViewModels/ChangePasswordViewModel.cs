using PocketHorseTrainer.Services;
using Splat;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class ChangePasswordViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public ChangePasswordViewModel()
        {
            ChangeCommand = new Command(() => Change());
        }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 8)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public ICommand ChangeCommand { get; set; }

        private async void Change()
        {
            var result = await apiServices.ChangePasswordAsync(OldPassword, NewPassword).ConfigureAwait(false);

            if (result)
            {
                _messageService.DisplayAlert("Success!", "Your password has been changed!");
                _routingService.NavigateTo("//profile");
            }
            else
            {
                _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
            }
        }
    }
}
