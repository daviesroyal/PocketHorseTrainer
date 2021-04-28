using PocketHorseTrainer.Services;

namespace PocketHorseTrainer.ViewModels
{
    internal class LoadingViewModel
    {
        private readonly RoutingService _routingService = new RoutingService();
        private readonly ApiServices apiServices = new ApiServices();

        //called by the view's OnAppearing method
        public void Init()
        {
            apiServices.RefreshTokenAsync(TokenSettings.AccessToken, TokenSettings.RefreshToken);

            if (!string.IsNullOrEmpty(TokenSettings.AccessToken) && !string.IsNullOrEmpty(TokenSettings.RefreshToken))
            {
                _routingService.NavigateTo("//main");
            }
            else
            {
                _routingService.NavigateTo("//login");
            }
        }
    }
}
