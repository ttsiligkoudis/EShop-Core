namespace Client
{
    public interface IClient
    {
        Task<T> GetAsync<T>(string api);

        Task<T> PutAsync<T>(T data, string api);

        Task<T> PostAsync<T>(T data, string api);

        Task<string> DeleteAsync(string api);

        void Dispose();
    }
}