using PocketHorseTrainer.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    internal class RegisterViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public RegisterViewModel()
        {
            RegisterCommand = new Command(() => Register());
            BackCommand = new Command(() => Back());
        }

        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your birthday.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public DateTime MaxDate { get; set; } = DateTime.Today.AddYears(-13);
        public DateTime MinDate { get; set; } = DateTime.Today.AddYears(-100);

        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1}  characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation passowrd do not match.")]
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand BackCommand { get; set; }

        private async void Register()
        {
            bool isRegistered = await apiServices.RegisterUserAsync(FirstName, LastName, UserName, Email, Phone, DOB, Password, ConfirmPassword).ConfigureAwait(false);

            if (isRegistered)
            {
                Message = $"Registration completed, please verify your email - {Email}";
                _messageService.DisplayAlert("Success!", Message);
                _routingService.NavigateTo("//login");
            }
            else
            {
                Message = "Something went wrong. Please try again.";
                _messageService.DisplayAlert("Uh oh!", Message);
            }
        }

        private void Back()
        {
            _routingService.GoBack();
        }
    }
}
