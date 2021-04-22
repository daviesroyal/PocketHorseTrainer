using PocketHorseTrainer.Services;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class ChangePasswordViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

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
        public string ConfirmPassword
        {
            get; set;
        }

        public ICommand ChangeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await apiServices.ChangePasswordAsync(AccessTokenSettings.AccessToken, OldPassword, NewPassword).ConfigureAwait(false);

                    if (result)
                    {
                        await Application.Current.MainPage.DisplayAlert("Success!", "Your password has been changed!", "OK").ConfigureAwait(false);
                        await Shell.Current.GoToAsync("//profile").ConfigureAwait(false);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Uh oh!", "Something went wrong.", "OK").ConfigureAwait(false);
                    }
                });
            }
        }
    }
}
