using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class UserProfileViewModel
    {
        private readonly ApiServices apiServices = new ApiServices();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string NewEmail { get; set; }
        public string Phone { get; set; }
        public string NewPhone { get; set; }

        public ICommand UpdateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (NewEmail != null)
                    {
                        var result = await apiServices.ChangeEmailAsync(AccessTokenSettings.AccessToken, NewEmail);
                        if (result)
                        {
                            await Application.Current.MainPage.DisplayAlert("Success!", "Please check your email for a verification link.", "OK");
                            await Shell.Current.GoToAsync("//profile");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Uh oh!", "Something went wrong.", "OK");
                        }
                    }
                    else if (NewPhone != null)
                    {
                        var result = await apiServices.ChangePhoneAsync(AccessTokenSettings.AccessToken, NewPhone);
                        if (result)
                        {
                            await Application.Current.MainPage.DisplayAlert("Success!", "Your phone number has been updated!", "OK");
                            await Shell.Current.GoToAsync("//profile");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Uh oh!", "Something went wrong.", "OK");
                        }
                    }
                });
            }
        }
    }
}
