using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using PocketHorseTrainer.Models;
using PocketHorseTrainer.ViewModels;

namespace PocketHorseTrainer.Services
{
    internal class ApiServices
    {
        public async Task<bool> RegisterUserAsync(string firstName, string lastName, string userName, string email, string phone, DateTime dob, string password, string confirmPassword)
        {
            var client = new HttpClient();

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

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                Constants.BaseAddress + "/api/Account/Register", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<string> LoginAsync(string userName, string password, bool rememberMe)
        {
            var client = new HttpClient();

            var model = new LoginBindingModel
            {
                UserName = userName,
                Password = password,
                RememberMe = rememberMe
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BaseAddress + "/api/Account/Login", httpContent);
            //do I need a token/cookie? unclear
            return response.Content.ToString();
        }
    }
}
