using System;
using System.Net.Http;
using System.Threading.Tasks;
using Geotab.Core;

namespace Geotab.Service
{
    public class NameApiService : BaseApiService
    {
        public HttpClient httpClient { get; set; }
        public NameApiService() : this(new HttpClient()) { }
        public NameApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetNames()
        {
            try
            {
                if (httpClient.BaseAddress == null) // not initialized yet
                {
                    httpClient.BaseAddress = new Uri(this.BaseUrl);
                    httpClient.Timeout = TimeSpan.FromSeconds(this.TimeoutInSeconds);
                }
                var requestUri = new Uri($"{BaseUrl}");
                Logger.Debug($"Making API Call to {requestUri}");

                // TODO: Implement correct logic for handling task progress
                Console.WriteLine($"Calling API {requestUri}. Please wait...");

                var response = await httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException httpException)
            {
                Logger.LogError("The http response failed due to network/server issue.", httpException);
                throw;
            }
            catch (Exception exception) when (exception is OperationCanceledException || exception is TaskCanceledException)
            {
                Logger.LogError("The http request timed out", exception);
                throw;
            }
        }
    }
}
