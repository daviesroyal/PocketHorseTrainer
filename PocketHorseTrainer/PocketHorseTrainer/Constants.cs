using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PocketHorseTrainer
{
    public static class Constants
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:62833" : "http://localhost:62833";
    }
}
