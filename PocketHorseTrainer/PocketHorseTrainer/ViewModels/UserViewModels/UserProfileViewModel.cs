﻿using PocketHorseTrainer.Services;
using System;
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
                        bool result = await apiServices.ChangeEmailAsync(AccessTokenSettings.AccessToken, NewEmail).ConfigureAwait(false);
                        if (result)
                        {
                            await Application.Current.MainPage.DisplayAlert("Success!", "Please check your email for a verification link.", "OK").ConfigureAwait(false);
                            await Shell.Current.GoToAsync("//profile").ConfigureAwait(false);
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Uh oh!", "Something went wrong.", "OK").ConfigureAwait(false);
                        }
                    }
                    else if (NewPhone != null)
                    {
                        var result = await apiServices.ChangePhoneAsync(AccessTokenSettings.AccessToken, NewPhone).ConfigureAwait(false);
                        if (result)
                        {
                            await Application.Current.MainPage.DisplayAlert("Success!", "Your phone number has been updated!", "OK").ConfigureAwait(false);
                            await Shell.Current.GoToAsync("//profile").ConfigureAwait(false);
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Uh oh!", "Something went wrong.", "OK").ConfigureAwait(false);
                        }
                    }
                });
            }
        }
    }
}