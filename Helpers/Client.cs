using Newtonsoft.Json;
using System.Text;

namespace Client
{
    public class Client<T>
    {
        private readonly HttpClient _client;
        private readonly string baseUrl = "https://eshopapi.myportofolio.eu/api/";

        public Client()
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            _client = new HttpClient(handler);
            //#if DEBUG
            //    baseUrl = DeviceInfo.Current.Platform == DevicePlatform.Android ? "http://10.0.2.2:5010/api/" : "https://localhost:5011/api/";
            //#endif
        }

        public async Task<T> GetAsync(string api)
        {
            using (var response = await _client.GetAsync(baseUrl + api))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return default;
        }

        public async Task<IEnumerable<T>> GetListAsync(string api)
        {
            using (var response = await _client.GetAsync(baseUrl + api))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }
            return default;
        }

        public async Task<T> PutAsync(T data, string api)
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

        public async Task<List<T>> PutListAsync(List<T> data, string api)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var response = await _client.PutAsync(baseUrl + api, content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }
            return default;
        }

        public async Task<T> PostAsync(T data, string api)
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

        public async Task<IEnumerable<T>> PostListAsync(IEnumerable<T> data, string api)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync(baseUrl + api, content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }
            return default;
        }

        public async Task<string> DeleteAsync(int id, string api)
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
