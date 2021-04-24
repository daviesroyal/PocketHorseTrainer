using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using Xamarin.Forms;

namespace PocketHorseTrainer
{
    public static class AccessTokenSettings
    {
        public static string AccessToken
        {
            get
            {
                return Application.Current.Properties.ContainsKey("accessToken") ? (string)Application.Current.Properties["accessToken"] : null;
            }
            set
            {
                if ((string)Application.Current.Properties["accessToken"] != value)
                {
                    Application.Current.Properties["accessToken"] = value;
                    Application.Current.SavePropertiesAsync();
                }
            }
        }

        public static string RefreshToken
        {
            get
            {
                return Application.Current.Properties.ContainsKey("refreshToken") ? (string)Application.Current.Properties["refreshToken"] : null;
            }
            set
            {
                if ((string)Application.Current.Properties["refreshToken"] != value)
                {
                    Application.Current.Properties["refreshToken"] = value;
                    Application.Current.SavePropertiesAsync();
                }
            }
        }
    }
}
