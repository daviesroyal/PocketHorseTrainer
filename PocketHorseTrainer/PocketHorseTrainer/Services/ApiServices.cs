using Newtonsoft.Json;
using PocketHorseTrainer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public class Result
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }

        public async Task<Result> LoginAsync(string userName, string password, bool rememberMe)
        {
            var client = GetBaseClient();

            var model = new LoginBindingModel
            {
                UserName = userName,
                Password = password,
                RememberMe = rememberMe
            };

            var json = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/login")
            {
                Content = content
            };
            
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                var handler = new JwtSecurityTokenHandler();

                dynamic jwtDynamic = handler.ReadJwtToken(token);

                var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
                var accessToken = jwtDynamic.Value<string>("access_token");

                AccessTokenSettings.AccessTokenExpirationDate = accessTokenExpiration;

                var result = new Result
                {
                    Success = true,
                    Message = accessToken
                };

                return result;
            }
            else
            {
                var message = response.Content.ReadAsStringAsync().Result;

                var result = new Result
                {
                    Success = false,
                    Message = message
                };

                return result;
            }

        }

        public async Task Logout(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/logout");
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                AccessTokenSettings.AccessToken = string.Empty;
                AccessTokenSettings.AccessTokenExpirationDate = DateTime.Now;
            }
        }
        #endregion

        #region horse
        public async Task<List<Horse>> GetAllHorses(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync("/api/horse");
            var horses = JsonConvert.DeserializeObject<List<Horse>>(json);

            return horses;
        }

        public async Task<Horse> GetHorse(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}");
            var horse = JsonConvert.DeserializeObject<Horse>(json);

            return horse;
        }

        public async Task AddHorse(Horse horse, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = JsonConvert.SerializeObject(horse);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _ = await client.PostAsync("/api/horse", content);
        }

        public async Task EditHorse(Horse horse, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = JsonConvert.SerializeObject(horse);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _ = await client.PutAsync("/api/horse", content);
        }

        public async Task DeleteHorse(int horseId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            _ = await client.DeleteAsync($"/api/horse/{horseId}");
        }
        #endregion

        #region journal
        public async Task<List<JournalEntry>> GetAllJournalEntries(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}/journal");
            var entries = JsonConvert.DeserializeObject<List<JournalEntry>>(json);

            return entries;
        }

        public async Task<JournalEntry> GetJournalEntry(string accessToken, int entryId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/journal/{entryId}");
            var entry = JsonConvert.DeserializeObject<JournalEntry>(json);

            return entry;
        }

        public async Task AddJournalEntry(string accessToken, int horseId, JournalEntry newEntry)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(newEntry);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PostAsync($"/api/horse/{horseId}/journal/", content);
        }

        public async Task EditJournalEntry(string accessToken, JournalEntry entry)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(entry);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/journal/{entry.Id}", content);
        }

        public async Task DeleteJournalEntry(int entryId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);

            _ = await client.DeleteAsync($"/api/horse/journal/{entryId}");
        }
        #endregion

        #region goal
        public async Task<List<Goal>> GetAllGoals(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}/goals");
            var goals = JsonConvert.DeserializeObject<List<Goal>>(json);

            return goals;
        }

        public async Task<Goal> GetGoal(string accessToken, int goalId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/goals/{goalId}");
            var goal = JsonConvert.DeserializeObject<Goal>(json);

            return goal;
        }

        public async Task AddGoal(string accessToken, int horseId, Goal goal)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(goal);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PostAsync($"/api/horse/{horseId}/goal/", content);
        }

        public async Task EditGoal(string accessToken, Goal goal)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(goal);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/goals/{goal.Id}", content);
        }

        public async Task DeleteGoal(int goalId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);

            _ = await client.DeleteAsync($"/api/horse/goals/{goalId}");
        }
        #endregion

        #region report
        public async Task<List<Report>> GetAllReports(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}/reports");
            var reports = JsonConvert.DeserializeObject<List<Report>>(json);

            return reports;
        }

        public async Task<Report> GetReport(string accessToken, int reportId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/reports/{reportId}");
            var report = JsonConvert.DeserializeObject<Report>(json);

            return report;
        }

        public async Task AddReport(string accessToken, int horseId, List<JournalEntry> entries)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(entries);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _ = await client.PostAsync($"/api/horse/{horseId}/report/", content);
        }

        public async Task EditReport(string accessToken, int reportId, List<JournalEntry> entries)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(entries);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/reports/{reportId}", content);
        }

        public async Task DeleteReport(int reportId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);

            _ = await client.DeleteAsync($"/api/horse/reports/{reportId}");
        }
        #endregion
    }
}
