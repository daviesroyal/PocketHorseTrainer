using Xamarin.Essentials;

namespace PocketHorseTrainer
{
    public static class Constants
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
    }
}
