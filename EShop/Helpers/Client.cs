using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EShop.Helpers
{
    public class Client<T>
    {
        public T Data;
        public List<T> DataList;
        private readonly HttpClient _client;

        public Client()
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            _client = new HttpClient(handler);
        }

        public async Task<T> GetAsync(string api)
        {
            using (var response = await _client.GetAsync("https://localhost:44384/api/" + api))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    Data = JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return Data;
        }

        public async Task<IEnumerable<T>> GetListAsync(string api)
        {
            using (var response = await _client.GetAsync("https://localhost:44384/api/" + api))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    DataList = JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }
            return DataList;
        }

        public async Task<T> PutAsync(T data, string api)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var response = await _client.PutAsync("https://localhost:44384/api/" + api, content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    Data = JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return Data;
        }

        public async Task<T> PostAsync(T data, string api)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync("https://localhost:44384/api/" + api, content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    Data = JsonConvert.DeserializeObject<T>(apiResponse);
            }
            return Data;
        }

        public async Task<IEnumerable<T>> PostListAsync(IEnumerable<T> data, string api)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync("https://localhost:44384/api/" + api, content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(apiResponse) && response.IsSuccessStatusCode)
                    DataList = JsonConvert.DeserializeObject<List<T>>(apiResponse);
            }
            return DataList;
        }

        public async Task<string> DeleteAsync(int id, string api)
        {
            using var response = await _client.DeleteAsync("https://localhost:44384/api/" + api);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return apiResponse;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
