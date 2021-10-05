using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Geotab.Service.Tests
{
    public class GeoTabApiServiceTest
    {
        const string MOCK_BASE_ADDRESS = "https://www.geotab-mockurl.com/";
        const int MOCK_TIMEOUT = 5;

        [Fact]
        public void GeotabApi_HttpClientBaseAddress_AreCorrect()
        {
            // Configure the service
            GeoTabApiService geoApi = new GeoTabApiService()
            {
                BaseUrl = MOCK_BASE_ADDRESS,
                TimeoutInSeconds = MOCK_TIMEOUT
            };

            // Invoke the Api
            var httpMessageHandler = MockHttpClientHelper.GetMockHandlerForSuccessResponse("");
            geoApi.httpClient = new HttpClient(httpMessageHandler.Object);
            var result = geoApi.GetCategories();

            // The hostaddress should have been set
            Assert.Equal(new Uri(MOCK_BASE_ADDRESS), geoApi.httpClient.BaseAddress);
        }

        [Fact]
        public async Task GeotabApi_GetCategoriesWithInvalidUrl_ThrowsHttpException()
        {
            // Configure the service
            GeoTabApiService geotabApi = new GeoTabApiService()
            {
                BaseUrl = MOCK_BASE_ADDRESS,
                TimeoutInSeconds = MOCK_TIMEOUT
            };
            var errorMessage = "Exception occurred on GetCategories() method";
            var httpMessageHandler = MockHttpClientHelper.GetMockHandlerForFailedResponse(errorMessage);
            geotabApi.httpClient = new HttpClient(httpMessageHandler.Object);

            // Assert the exception
            Exception exception = await Assert.ThrowsAsync<HttpRequestException>(() => geotabApi.GetCategories());
            Assert.Contains(errorMessage, exception.Message);
        }

        [Fact]
        public void GeotabApi_GetCategories_ReturnsValidCategoryList()
        {
            // Configure the service
            GeoTabApiService geotabApi = new GeoTabApiService()
            {
                BaseUrl = $"{ MOCK_BASE_ADDRESS}joke_category",
                TimeoutInSeconds = MOCK_TIMEOUT
            };

            // Mock HttpClient
            string mockString = "['animal','celebrity','food']";
            var httpMessageHandler = MockHttpClientHelper.GetMockHandlerForSuccessResponse(mockString);
            geotabApi.httpClient = new HttpClient(httpMessageHandler.Object);

            // Assert the results
            var result = geotabApi.GetCategories();
            Assert.Equal(mockString, result.Result);
        }

        [Fact]
        public void GeotabApi_GetJoke_ReturnsMultipleJokes()
        {
            // Configure the service
            GeoTabApiService geotabApi = new GeoTabApiService()
            {
                BaseUrl = $"{ MOCK_BASE_ADDRESS}joke",
                TimeoutInSeconds = MOCK_TIMEOUT
            };

            // Mock HttpClient
            int numberOfJokes = 4;
            string mockString = "{'icon_url': 'test.png','value': 'Chuck Norris is never hungry.'}";
            var httpMessageHandler = MockHttpClientHelper.GetMockHandlerForSuccessResponse(mockString);
            geotabApi.httpClient = new HttpClient(httpMessageHandler.Object);

            // Assert the results
            var result = geotabApi.GetRandomMultipleJokes(null, numberOfJokes);
            List<string> mockResults = result.Result;
            Assert.Equal(numberOfJokes, mockResults.Count);
            Assert.Contains(mockString, mockResults[0]);
        }
    }
}
