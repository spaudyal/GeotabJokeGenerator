using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Geotab.Core;

namespace Geotab.Service
{
    public class GeoTabApiService : BaseApiService
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
                    httpClient.BaseAddress = new Uri(this.BaseUrl);
                    httpClient.Timeout = TimeSpan.FromSeconds(this.TimeoutInSeconds);
                }
                var requestUri = new Uri($"{BaseUrl}{GeotabApiConstants.JOKE_ENDPOINT}?{queryParameters}");
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
        }

        public async Task<List<string>> GetRandomMultipleJokes(string queryParameters, int numberOfJokes)
        {
            try
            {
                var requestUri = new Uri($"{BaseUrl}{GeotabApiConstants.JOKE_ENDPOINT}?{queryParameters}");
                Logger.Debug($"Making Multiple({numberOfJokes}) API Calls to {requestUri}");
                List<Task<string>> taskList = new();
                for (int i = 0; i < numberOfJokes; i++)
                {
                    var task = GetRandomJokes(queryParameters);
                    taskList.Add(task);
                }

                // Await the completion of all the running tasks. 
                var responses = await Task.WhenAll(taskList);
                return await Task.FromResult<List<string>>(new(responses));
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

        public async Task<string> GetCategories()
        {
            try
            {
                if (httpClient.BaseAddress == null) // not initialized yet
                {
                    httpClient.BaseAddress = new Uri(this.BaseUrl);
                    httpClient.Timeout = TimeSpan.FromSeconds(this.TimeoutInSeconds);
                }
                var requestUri = new Uri($"{BaseUrl}{GeotabApiConstants.JOKE_CATEGORY_ENDPOINT}");
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
