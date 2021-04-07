using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PocketHorseTrainer.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PocketHorseTrainer.Services
{
    internal class ApiServices
    {
        #region httpClientSetup
        public HttpClient GetBaseClient()
        {
            Uri baseAddress = new Uri(Constants.BaseAddress);

            var client = new HttpClient { BaseAddress = baseAddress };

            return client;
        }

        public HttpClient GetAuthorizedClient(string accessToken)
        {
            var client = GetBaseClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return client;
        }
        #endregion

        #region userCredentials
        public async Task<bool> RegisterUserAsync(string firstName, string lastName, string userName, string email, string phone, DateTime dob, string password, string confirmPassword)
        {
            var client = GetBaseClient();

            var model = new RegisterBindingModel
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = email,
                Phone = phone,
                DOB = dob,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(
                "/api/account/register", content);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<string> LoginAsync(string userName, string password, bool rememberMe)
        {
            var client = GetBaseClient();

            var model = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("rememberMe", rememberMe.ToString()),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/login")
            {
                Content = new FormUrlEncodedContent(model)
            };

            HttpResponseMessage response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            
            var content = response.Content.ToString();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            var accessToken = jwtDynamic.Value<string>("access_token");

            AccessTokenSettings.AccessTokenExpirationDate = accessTokenExpiration;

            return accessToken;
        }
        #endregion

        #region horseProfile

        #endregion
    }
}
