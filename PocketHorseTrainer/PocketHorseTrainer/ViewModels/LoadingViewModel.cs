using PocketHorseTrainer.Services.Identity;
using PocketHorseTrainer.Services.Routing;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.ViewModels
{
    class LoadingViewModel : BaseViewModel
    {
        private readonly IRoutingService routingService;
        private readonly IIdentityService identityService;

        public LoadingViewModel(IRoutingService routingService = null, IIdentityService identityService = null)
        {
            this.routingService = routingService ?? Locator.Current.GetService<IRoutingService>();
            this.identityService = identityService ?? Locator.Current.GetService<IIdentityService>();
        }

        // Called by the views OnAppearing method
        public async void Init()
        {
            var isAuthenticated = await identityService.VerifyRegistration();
            if (isAuthenticated)
            {
                await routingService.NavigateTo("///main");
            }
            else
            {
                await routingService.NavigateTo("///login");
            }
        }
    }
}
