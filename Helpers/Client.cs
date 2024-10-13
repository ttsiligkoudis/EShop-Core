using Newtonsoft.Json;
using System.Text;

namespace Client
{
    public class Client : IClient
    {
        private readonly HttpClient _client;
        private readonly string baseUrl = "https://eshopapi.myportofolio.eu/api/";

        public Client(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string api)
        {
            using (var response = await _client.GetAsync(baseUrl + api))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return default;
        }

        public async Task<T> PutAsync<T>(T data, string api)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var response = await _client.PutAsync(baseUrl + api, content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return default;
        }

        public async Task<T> PostAsync<T>(T data, string api)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync(baseUrl + api, content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return default;
        }

        public async Task<string> DeleteAsync(string api)
        {
            using var response = await _client.DeleteAsync(baseUrl + api);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return apiResponse;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
