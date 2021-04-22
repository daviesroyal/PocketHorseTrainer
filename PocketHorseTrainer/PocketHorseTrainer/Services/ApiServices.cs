using Newtonsoft.Json;
using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
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
        public class Result
        {
            public bool Success { get; set; }
            public string Message { get; set; }
        }

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

        #region userManagement
        public async Task<bool> RegisterUserAsync(string firstName, string lastName, string userName, string email, string phone, DateTime dob, string password, string confirmPassword)
        {
            var client = GetBaseClient();

            var model = new
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

            HttpResponseMessage response = await client.PostAsync("/api/account/register", content).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<Result> LoginAsync(string userName, string password, bool rememberMe)
        {
            var client = GetBaseClient();

            var model = new
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

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var accessToken = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var result = new Result
                {
                    Success = true,
                    Message = accessToken
                };

                return result;
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var result = new Result
                {
                    Success = false,
                    Message = message
                };

                return result;
            }
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var client = GetBaseClient();

            StringContent content = new StringContent(email, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/forgotpassword")
            {
                Content = content
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangePasswordAsync(string accessToken, string oldPassword, string newPassword)
        {
            var client = GetAuthorizedClient(accessToken);

            var passwords = new
            {
                OldPassword = oldPassword,
                NewPassword = newPassword
            };

            var json = JsonConvert.SerializeObject(passwords);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/changepassword")
            {
                Content = content
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangeEmailAsync(string accessToken, string email)
        {
            var client = GetAuthorizedClient(accessToken);

            StringContent content = new StringContent(email, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/changeemail")
            {
                Content = content
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangePhoneAsync(string accessToken, string phone)
        {
            var client = GetAuthorizedClient(accessToken);

            StringContent content = new StringContent(phone, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/changephone")
            {
                Content = content
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Logout(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/logout");
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            AccessTokenSettings.AccessToken = string.Empty;

            return true;
        }
        #endregion

        #region horse
        public async Task<List<Horse>> GetAllHorses(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync("/api/horse").ConfigureAwait(false);
            var horses = JsonConvert.DeserializeObject<List<Horse>>(json);

            return horses;
        }

        public async Task<Horse> GetHorse(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}").ConfigureAwait(false);
            var horse = JsonConvert.DeserializeObject<Horse>(json);

            return horse;
        }

        public async Task AddHorse(Horse horse, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = JsonConvert.SerializeObject(horse);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _ = await client.PostAsync("/api/horse", content).ConfigureAwait(false);
        }

        public async Task EditHorse(Horse horse, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = JsonConvert.SerializeObject(horse);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _ = await client.PutAsync("/api/horse", content).ConfigureAwait(false);
        }

        public async Task DeleteHorse(int horseId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            _ = await client.DeleteAsync($"/api/horse/{horseId}").ConfigureAwait(false);
        }
        #endregion

        #region journal
        public async Task<List<JournalEntry>> GetAllJournalEntries(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}/journal").ConfigureAwait(false);
            var entries = JsonConvert.DeserializeObject<List<JournalEntry>>(json);

            return entries;
        }

        public async Task<JournalEntry> GetJournalEntry(string accessToken, int entryId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/journal/{entryId}").ConfigureAwait(false);
            var entry = JsonConvert.DeserializeObject<JournalEntry>(json);

            return entry;
        }

        public async Task AddJournalEntry(string accessToken, int horseId, JournalEntry newEntry)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(newEntry);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PostAsync($"/api/horse/{horseId}/journal/", content).ConfigureAwait(false);
        }

        public async Task EditJournalEntry(string accessToken, JournalEntry entry)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(entry);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/journal/{entry.Id}", content).ConfigureAwait(false);
        }

        public async Task DeleteJournalEntry(int entryId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);

            _ = await client.DeleteAsync($"/api/horse/journal/{entryId}").ConfigureAwait(false);
        }
        #endregion

        #region goal
        public async Task<List<Goal>> GetAllGoals(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}/goals").ConfigureAwait(false);
            var goals = JsonConvert.DeserializeObject<List<Goal>>(json);

            return goals;
        }

        public async Task<Goal> GetGoal(string accessToken, int goalId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/goals/{goalId}").ConfigureAwait(false);
            var goal = JsonConvert.DeserializeObject<Goal>(json);

            return goal;
        }

        public async Task AddGoal(string accessToken, int horseId, Goal goal)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(goal);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PostAsync($"/api/horse/{horseId}/goal/", content).ConfigureAwait(false);
        }

        public async Task EditGoal(string accessToken, Goal goal)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(goal);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/goals/{goal.Id}", content).ConfigureAwait(false);
        }

        public async Task DeleteGoal(int goalId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);

            _ = await client.DeleteAsync($"/api/horse/goals/{goalId}").ConfigureAwait(false);
        }
        #endregion

        #region report
        public async Task<List<Report>> GetAllReports(string accessToken, int horseId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/{horseId}/reports").ConfigureAwait(false);
            var reports = JsonConvert.DeserializeObject<List<Report>>(json);

            return reports;
        }

        public async Task<Report> GetReport(string accessToken, int reportId)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync($"/api/horse/reports/{reportId}").ConfigureAwait(false);
            var report = JsonConvert.DeserializeObject<Report>(json);

            return report;
        }

        public async Task AddReport(string accessToken, int horseId, List<JournalEntry> entries)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(entries);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _ = await client.PostAsync($"/api/horse/{horseId}/report/", content).ConfigureAwait(false);
        }

        public async Task EditReport(string accessToken, int reportId, List<JournalEntry> entries)
        {
            var client = GetAuthorizedClient(accessToken);

            var json = JsonConvert.SerializeObject(entries);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/reports/{reportId}", content).ConfigureAwait(false);
        }

        public async Task DeleteReport(int reportId, string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);

            _ = await client.DeleteAsync($"/api/horse/reports/{reportId}").ConfigureAwait(false);
        }
        #endregion

        #region barn
        public async Task<List<Barn>> GetBarns(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync("/api/admin/barns").ConfigureAwait(false);
            var barns = JsonConvert.DeserializeObject<List<Barn>>(json);

            return barns;
        }
        #endregion

        #region supportClasses

        #region breed
        public async Task<List<Breed>> GetBreeds(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync("/api/admin/breeds").ConfigureAwait(false);
            var breeds = JsonConvert.DeserializeObject<List<Breed>>(json);

            return breeds;
        }
        #endregion

        #region coatColor
        public async Task<List<CoatColor>> GetColors(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync("/api/admin/colors").ConfigureAwait(false);
            var colors = JsonConvert.DeserializeObject<List<CoatColor>>(json);

            return colors;
        }
        #endregion

        #region markings

        #region faceMarking
        public async Task<List<FaceMarking>> GetFaceMarkings(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync("/api/admin/markings/face").ConfigureAwait(false);
            var markings = JsonConvert.DeserializeObject<List<FaceMarking>>(json);

            return markings;
        }
        #endregion

        #region legMarking
        public async Task<List<LegMarking>> GetLegMarkings(string accessToken)
        {
            var client = GetAuthorizedClient(accessToken);
            var json = await client.GetStringAsync("/api/admin/markings/face").ConfigureAwait(false);
            var markings = JsonConvert.DeserializeObject<List<LegMarking>>(json);

            return markings;
        }
        #endregion

        #endregion

        #endregion
    }
}
