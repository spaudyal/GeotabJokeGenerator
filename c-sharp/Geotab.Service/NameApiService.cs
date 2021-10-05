using System;
using System.Net.Http;
using System.Threading.Tasks;
using Geotab.Core;

namespace Geotab.Service
{
    internal class NameApiService : BaseApiService
    {
        public HttpClient httpClient { get; set; }
        public NameApiService() : this(new HttpClient()) { }
        public NameApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Getnames()
        {
            try
            {
                if (httpClient.BaseAddress == null) // not initialized yet
                {
                    httpClient.BaseAddress = new Uri(GeotabApiConstants.NAME_SERVER_URL.TrimEnd('/'));
                    httpClient.Timeout = TimeSpan.FromSeconds(GeotabApiConstants.TIMEOUT_SECONDS);
                }
                var requestUri = new Uri($"{BaseUrl}");
                Logger.Debug($"Making API Call to {requestUri}");
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
