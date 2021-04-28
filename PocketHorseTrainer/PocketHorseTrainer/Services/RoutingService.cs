using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketHorseTrainer.Services
{
    public class RoutingService
    {
        public void NavigateTo(string route)
        {
            Device.InvokeOnMainThreadAsync(async () => await Shell.Current.GoToAsync(route).ConfigureAwait(false));
        }

        public void GoBack()
        {
            Device.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PopAsync().ConfigureAwait(false));
        }

        public void GoBackModal()
        {
            Device.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PopModalAsync().ConfigureAwait(false));
        }

        public void GoTo(Page page)
        {
            Device.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PushAsync(page).ConfigureAwait(false));
        }

        public void GoToModal(Page page)
        {
            Device.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PushModalAsync(page).ConfigureAwait(false));
        }
    }
}
