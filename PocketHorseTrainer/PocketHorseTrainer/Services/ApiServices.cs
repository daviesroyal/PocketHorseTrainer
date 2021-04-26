using Newtonsoft.Json;
using PocketHorseTrainer.Models;
using PocketHorseTrainer.Models.Horses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PocketHorseTrainer.Services
{
    internal class ApiServices
    {
        internal class Tokens
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }

        #region httpClientSetup
        public HttpClient GetBaseClient()
        {
            Uri baseAddress = new Uri(Constants.BaseAddress);

            return new HttpClient { BaseAddress = baseAddress };
        }

        public HttpClient GetAuthorizedClient()
        {
            HttpClient client = GetBaseClient();

            RefreshTokenAsync(TokenSettings.AccessToken, TokenSettings.RefreshToken);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenSettings.AccessToken);

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

        public async Task<bool> LoginAsync(string userName, string password, bool rememberMe)
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

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var tokens = JsonConvert.DeserializeObject<Tokens>(responseContent);
            TokenSettings.AccessToken = tokens.AccessToken;
            TokenSettings.RefreshToken = tokens.RefreshToken;
            return true;
        }

        public async Task<bool> Logout()
        {
            var client = GetAuthorizedClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/logout");
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            TokenSettings.AccessToken = null;
            TokenSettings.RefreshToken = null;

            return true;
        }

        public async void RefreshTokenAsync(string accessToken, string refreshToken)
        {
            var client = GetBaseClient();
            var tokens = new
            {
                accessToken,
                refreshToken,
            };
            var json = JsonConvert.SerializeObject(tokens);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/token/refresh")
            {
                Content = content
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Tokens>(responseContent);
            TokenSettings.AccessToken = result.AccessToken;
            TokenSettings.RefreshToken = result.RefreshToken;
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

        public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            var client = GetAuthorizedClient();

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

        public async Task<bool> ChangeEmailAsync(string email)
        {
            var client = GetAuthorizedClient();

            StringContent content = new StringContent(email, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/changeemail")
            {
                Content = content
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangePhoneAsync(string phone)
        {
            var client = GetAuthorizedClient();

            StringContent content = new StringContent(phone, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account/changephone")
            {
                Content = content
            };

            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
        }

        #endregion

        #region horse
        public async Task<List<Horse>> GetAllHorses()
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync("/api/horse/").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Horse>>(json);
        }

        public async Task<Horse> GetHorse(int horseId)
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync($"/api/horse/{horseId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Horse>(json);
        }

        public async Task<bool> AddHorse(Horse horse)
        {
            var client = GetAuthorizedClient();
            var json = JsonConvert.SerializeObject(horse);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync("/api/horse/add", content).ConfigureAwait(false);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> EditHorse(Horse horse)
        {
            var client = GetAuthorizedClient();
            var json = JsonConvert.SerializeObject(horse);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await client.PutAsync("/api/horse/edit", content).ConfigureAwait(false);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteHorse(int horseId)
        {
            var client = GetAuthorizedClient();
            var result = await client.DeleteAsync($"/api/horse/{horseId}").ConfigureAwait(false);

            return result.IsSuccessStatusCode;
        }
        #endregion

        #region journal
        public async Task<List<JournalEntry>> GetAllJournalEntries(int horseId)
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync($"/api/horse/{horseId}/journal").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<JournalEntry>>(json);
        }

        public async Task<JournalEntry> GetJournalEntry(int entryId)
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync($"/api/horse/journal/{entryId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<JournalEntry>(json);
        }

        public async Task AddJournalEntry(int horseId, JournalEntry newEntry)
        {
            var client = GetAuthorizedClient();

            var json = JsonConvert.SerializeObject(newEntry);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PostAsync($"/api/horse/{horseId}/journal/", content).ConfigureAwait(false);
        }

        public async Task EditJournalEntry(JournalEntry entry)
        {
            var client = GetAuthorizedClient();

            var json = JsonConvert.SerializeObject(entry);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/journal/{entry.Id}", content).ConfigureAwait(false);
        }

        public async Task DeleteJournalEntry(int entryId)
        {
            var client = GetAuthorizedClient();

            _ = await client.DeleteAsync($"/api/horse/journal/{entryId}").ConfigureAwait(false);
        }
        #endregion

        #region goal
        public async Task<List<Goal>> GetAllGoals(int horseId)
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync($"/api/horse/{horseId}/goals").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Goal>>(json);
        }

        public async Task<Goal> GetGoal(int goalId)
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync($"/api/horse/goals/{goalId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Goal>(json);
        }

        public async Task AddGoal(int horseId, Goal goal)
        {
            var client = GetAuthorizedClient();

            var json = JsonConvert.SerializeObject(goal);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PostAsync($"/api/horse/{horseId}/goal/", content).ConfigureAwait(false);
        }

        public async Task EditGoal(Goal goal)
        {
            var client = GetAuthorizedClient();

            var json = JsonConvert.SerializeObject(goal);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/goals/{goal.Id}", content).ConfigureAwait(false);
        }

        public async Task DeleteGoal(int goalId)
        {
            var client = GetAuthorizedClient();

            _ = await client.DeleteAsync($"/api/horse/goals/{goalId}").ConfigureAwait(false);
        }
        #endregion

        #region report
        public async Task<List<Report>> GetAllReports(int horseId)
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync($"/api/horse/{horseId}/reports").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Report>>(json);
        }

        public async Task<Report> GetReport(int reportId)
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync($"/api/horse/reports/{reportId}").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Report>(json);
        }

        public async Task AddReport(int horseId, List<JournalEntry> entries)
        {
            var client = GetAuthorizedClient();

            var json = JsonConvert.SerializeObject(entries);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _ = await client.PostAsync($"/api/horse/{horseId}/report/", content).ConfigureAwait(false);
        }

        public async Task EditReport(int reportId, List<JournalEntry> entries)
        {
            var client = GetAuthorizedClient();

            var json = JsonConvert.SerializeObject(entries);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            _ = await client.PutAsync($"/api/horse/reports/{reportId}", content).ConfigureAwait(false);
        }

        public async Task DeleteReport(int reportId)
        {
            var client = GetAuthorizedClient();

            _ = await client.DeleteAsync($"/api/horse/reports/{reportId}").ConfigureAwait(false);
        }
        #endregion

        #region barn
        public async Task<List<Barn>> GetBarns()
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync("/api/admin/barns").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Barn>>(json);
        }
        #endregion

        #region supportClasses

        #region breed
        public async Task<List<Breed>> GetBreeds()
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync("/api/admin/breeds").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Breed>>(json);
        }
        #endregion

        #region coatColor
        public async Task<List<CoatColor>> GetColors()
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync("/api/admin/colors").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<CoatColor>>(json);
        }
        #endregion

        #region markings

        public async Task CreateMarkingsAsync(Markings markings)
        {
            var client = GetAuthorizedClient();

            var json = JsonConvert.SerializeObject(markings);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/admin/markings")
            {
                Content = content
            };

            _ = await client.SendAsync(request).ConfigureAwait(false);
        }

        #region faceMarking
        public async Task<List<FaceMarking>> GetFaceMarkings()
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync("/api/admin/markings/face").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<FaceMarking>>(json);
        }
        #endregion

        #region legMarking
        public async Task<List<LegMarking>> GetLegMarkings()
        {
            var client = GetAuthorizedClient();
            var json = await client.GetStringAsync("/api/admin/markings/leg").ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<LegMarking>>(json);
        }
        #endregion

        #endregion

        #endregion
    }
}
