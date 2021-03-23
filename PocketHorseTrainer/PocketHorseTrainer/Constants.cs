using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PocketHorseTrainer
{
    public static class Constants
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.1.1:44394" : "http://localhost:44394";
    }
}
