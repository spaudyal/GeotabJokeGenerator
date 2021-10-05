using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace Geotab.Service.Tests
{
    class MockHttpClientHelper
    {
        public static Mock<HttpMessageHandler> GetMockHandlerForSuccessResponse(string responseString)
        {
            // Mock HttpClient
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseString)
                });
            return httpMessageHandler;
        }

        public static Mock<HttpMessageHandler> GetMockHandlerForFailedResponse(string errorMessage)
        {
            // Mock HttpClient
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException(errorMessage));
            return httpMessageHandler;
        }
    }
}
