using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PocketHorseTrainer
{
    public static class Constants
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:44394" : "https://localhost:44394";
    }
}
