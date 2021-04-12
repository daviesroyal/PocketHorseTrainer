using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketHorseTrainer.ViewModels
{
    public class EditGoalViewModel
    {
        readonly ApiServices apiServices = new ApiServices();

        public Goal Goal { get; set; }

        readonly string accessToken = AccessTokenSettings.AccessToken;

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await apiServices.EditGoal(accessToken, Goal);
                });
            }
        }
    }
}
