using Newtonsoft.Json;
using PocketHorseTrainer.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PocketHorseTrainer.Services
{
    internal class ApiServices
    {
        public async Task<bool> RegisterUserAsync(string firstName, string lastName, string userName, string email, string phone, DateTime dob, string password, string confirmPassword)
        {
            Uri baseAddress = new Uri(Constants.BaseAddress);

            var client = new HttpClient { BaseAddress = baseAddress };

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
            Uri baseAddress = new Uri(Constants.BaseAddress);

            var client = new HttpClient { BaseAddress = baseAddress };

            var model = new LoginBindingModel
            {
                UserName = userName,
                Password = password,
                RememberMe = rememberMe //keeps defaulting to false
            };

            var json = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/account/login", content);

            response.EnsureSuccessStatusCode();
            
            //configure for token
            return response.Content.ToString();
        }

        //TODO: write logout service
    }
}
