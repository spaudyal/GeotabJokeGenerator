using System;
using System.Net.Http;
using System.Threading.Tasks;
using Geotab.Core;
using Geotab.Model;

namespace Geotab.Service
{
    class GeoTabApiService : BaseApiService
    {
        public HttpClient httpClient { get; set; }
        public GeoTabApiService() : this(new HttpClient()) { }
        public GeoTabApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetRandomJokes(string queryParameters)
        {
            try
            {
                if (httpClient.BaseAddress == null) // not initialized yet
                {
                    httpClient.BaseAddress = new Uri(GeotabApiConstants.GEOTAB_API_URL);
                    httpClient.Timeout = TimeSpan.FromSeconds(GeotabApiConstants.TIMEOUT_SECONDS);
                }
                var requestUri = new Uri($"{BaseUrl}{GeotabApiConstants.JOKE_ENDPOINT}?{queryParameters}");
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
        }

        public async Task<string> GetCategories()
        {
            try
            {
                if (httpClient.BaseAddress == null) // not initialized yet
                {
                    httpClient.BaseAddress = new Uri(GeotabApiConstants.GEOTAB_API_URL);
                    httpClient.Timeout = TimeSpan.FromSeconds(GeotabApiConstants.TIMEOUT_SECONDS);
                }
                var requestUri = new Uri($"{BaseUrl}{GeotabApiConstants.JOKE_CATEGORY_ENDPOINT}");
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
        }
    }
}
