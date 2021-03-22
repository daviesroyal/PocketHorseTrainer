using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    class RegisterViewModel
    {
        private readonly ApiConnector _apiConnector = new ApiConnector();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isRegistered = await _apiConnector.RegisterUserAsync
                        (FirstName, LastName, UserName, Email, Phone, DOB, Password, ConfirmPassword);

                    if (isRegistered)
                    {
                        //navigate instead of message
                        Message = $"Registration completed, please verify your email - {Email}";
                    }
                    else
                    {
                        Message = "Something went wrong. Please try again.";
                    }
                });
            }
        }
    }
}
