using BlazorWeb.Models;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace TestBlazor
{
    //public class UnitTest1
    //{
    //    [Fact]
    //    public async Task AddProductAsync_Should_NotThrowException()
    //    {
    //        // Arrange
    //        var product = new Product {  Price = 1000 };

    //        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

    //        mockHttpMessageHandler
    //            .Protected()
    //            .Setup<Task<HttpResponseMessage>>(
    //                "SendAsync",
    //                ItExpr.IsAny<HttpRequestMessage>(),
    //                ItExpr.IsAny<CancellationToken>()
    //            )
    //            .ReturnsAsync(new HttpResponseMessage
    //            {
    //                StatusCode = HttpStatusCode.OK
    //            });

    //        // Tạo HttpClient và đặt BaseAddress
    //        var httpClient = new HttpClient(mockHttpMessageHandler.Object)
    //        {
    //            BaseAddress = new Uri("https://localhost:7149/") // 👈 Cần thiết lập BaseAddress
    //        };

    //        // Mock IHttpClientFactory
    //        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
    //        mockHttpClientFactory
    //            .Setup(_ => _.CreateClient(It.IsAny<string>()))
    //            .Returns(httpClient);

    //        var productService = new ProductService(mockHttpClientFactory.Object);

    //        // Act & Assert
    //        await productService.AddProductAsync(product);
    //    }


    //    [Fact]
    //    public async Task AddProductAsync_ShouldReturnFalse_WhenHttpFails()
    //    {
    //        // Arrange
    //        var product = new Product { Id = 1, Name = "Laptop", Price = 1000 };

    //        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

    //        mockHttpMessageHandler
    //            .Protected()
    //            .Setup<Task<HttpResponseMessage>>(
    //                "SendAsync",
    //                ItExpr.IsAny<HttpRequestMessage>(),
    //                ItExpr.IsAny<CancellationToken>()
    //            )
    //            .ReturnsAsync(new HttpResponseMessage
    //            {
    //                StatusCode = HttpStatusCode.OK
    //            });

    //        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

    //        // Mock IHttpClientFactory
    //        var mockHttpClientFactory = new Mock<IHttpClientFactory>();
    //        mockHttpClientFactory
    //            .Setup(_ => _.CreateClient(It.IsAny<string>()))
    //            .Returns(httpClient);

    //        var productService = new ProductService(mockHttpClientFactory.Object);

    //        // Act & Assert
    //        await productService.AddProductAsync(product);
    //    }
    //}
}
