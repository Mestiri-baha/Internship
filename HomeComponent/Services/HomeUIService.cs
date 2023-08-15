using HomeComponent.Model;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HomeComponent.Services
{
    public class HomeUIService
    {
        protected readonly HttpClient _httpClient;
        public HomeUIService(HttpClient httpClient)
        {

            _httpClient = httpClient;
           

        }
        public async Task<HomeUIConfiguration> GetHistoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<HomeUIConfiguration>(_httpClient.BaseAddress + "/GetHistory");
        }
        public async Task<HomeUIConfiguration> GetControlsAsync()
        {
            return await _httpClient.GetFromJsonAsync<HomeUIConfiguration>(_httpClient.BaseAddress + "/GetControls");
        }
        public async Task<HomeUIConfiguration> GetShortcutsAsync()
        {
            return await _httpClient.GetFromJsonAsync<HomeUIConfiguration>(_httpClient.BaseAddress   + "/GetShortcuts");
        }
        public async Task<HomeUIConfiguration> GetFavouriteListAsync()
        {
            return await _httpClient.GetFromJsonAsync<HomeUIConfiguration>(_httpClient.BaseAddress + "/GetFavouriteList");
        }
        public async Task<string> GetUserNameAsync()
        {
            return await _httpClient.GetFromJsonAsync<string>(_httpClient.BaseAddress + "/GetUserName");
        }
        public async Task<HomeUIConfiguration> GetActionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<HomeUIConfiguration>(_httpClient.BaseAddress + "/GetActions");
        }
        public async Task<HomeUIConfiguration> GetReportsAsync()
        {
            return await _httpClient.GetFromJsonAsync<HomeUIConfiguration>(_httpClient.BaseAddress + "/GetReports");
        }
        public async Task<HomeUIConfiguration> GetNewsAsync()
        {
            return await _httpClient.GetFromJsonAsync<HomeUIConfiguration>(_httpClient.BaseAddress + "/GetNews");
        }

    }
}
