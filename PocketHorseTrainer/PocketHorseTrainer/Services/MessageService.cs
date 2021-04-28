using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketHorseTrainer.Services
{
    public class MessageService
    {
        public void DisplayAlert(string title, string message, string accept = "OK")
        {
            Device.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayAlert(title, message, accept).ConfigureAwait(false));
        }
    }
}
