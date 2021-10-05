using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Geotab.Service.Tests
{
    public class NameApiServiceTest
    {
        const string MOCK_BASE_ADDRESS = "https://www.nameserver-mockurl.com/api/";
        const int MOCK_TIMEOUT = 5;

        [Fact]
        public void NameApi_HttpClientBaseAddress_AreCorrect()
        {
            // Configure the service
            NameApiService nameApi = new NameApiService()
            {
                BaseUrl = MOCK_BASE_ADDRESS,
                TimeoutInSeconds = MOCK_TIMEOUT
            };

            // Invoke the Api
            var httpMessageHandler = MockHttpClientHelper.GetMockHandlerForSuccessResponse("");
            nameApi.httpClient = new HttpClient(httpMessageHandler.Object);
            var result = nameApi.GetNames();


            // The hostaddress should have been set
            Assert.Equal(new Uri(MOCK_BASE_ADDRESS), nameApi.httpClient.BaseAddress);
            Assert.Equal(TimeSpan.FromSeconds(MOCK_TIMEOUT), nameApi.httpClient.Timeout);
        }

        [Fact]
        public async Task NameApi_GetNamesWithInvalidUrl_ThrowsHttpException()
        {
            // Configure the service
            NameApiService nameApi = new NameApiService()
            {
                BaseUrl = MOCK_BASE_ADDRESS,
                TimeoutInSeconds = MOCK_TIMEOUT
            };
            var errorMessage = "Exception occurred on GetNames() method";
            var httpMessageHandler = MockHttpClientHelper.GetMockHandlerForFailedResponse(errorMessage);
            nameApi.httpClient = new HttpClient(httpMessageHandler.Object);

            // Assert the exception
            Exception exception = await Assert.ThrowsAsync<HttpRequestException>(() => nameApi.GetNames());
            Assert.Contains(errorMessage, exception.Message);
        }

        [Fact]
        public void NameApi_GetNames_ReturnsValidApiData()
        {
            // Configure the service
            NameApiService nameApi = new NameApiService()
            {
                BaseUrl = MOCK_BASE_ADDRESS,
                TimeoutInSeconds = MOCK_TIMEOUT
            };

            // Mock HttpClient
            string mockString = "{'name':'Sharon','surname':'Johnston','gender':'female','region':'United States'}";
            var httpMessageHandler = MockHttpClientHelper.GetMockHandlerForSuccessResponse(mockString);
            nameApi.httpClient = new HttpClient(httpMessageHandler.Object);

            // Assert the results
            var result = nameApi.GetNames();
            Assert.Equal(mockString, result.Result);
        }
    }
}
