using PocketHorseTrainer.Services;
using Splat;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();
        private readonly RoutingService _routingService = new RoutingService();
        private readonly MessageService _messageService = new MessageService();

        public UserProfileViewModel()
        {
            UpdateCommand = new Command(() => Update());
        }

        //need to map properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string _displayName;
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            private set
            {
                _displayName = $"{FirstName} {LastName}";
                OnPropertyChanged();
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
            }
        }
        public DateTime DOB { get; set; }

        public string NewEmail { get; set; }
        public string NewPhone { get; set; }

        public ICommand UpdateCommand { get; set; }

        private async void Update()
        {
            if (NewEmail != null)
            {
                bool result = await apiServices.ChangeEmailAsync(NewEmail).ConfigureAwait(false);
                if (result)
                {
                    _messageService.DisplayAlert("Success!", "Please check your email for a verification link.");
                    _routingService.NavigateTo("//profile");
                }
                else
                {
                    _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
                }
            }
            else if (NewPhone != null)
            {
                var result = await apiServices.ChangePhoneAsync(NewPhone).ConfigureAwait(false);
                if (result)
                {
                    _messageService.DisplayAlert("Success!", "Your phone number has been updated!");
                    _routingService.NavigateTo("//profile");
                }
                else
                {
                    _messageService.DisplayAlert("Uh oh!", "Something went wrong.");
                }
            }
        }
    }
}
