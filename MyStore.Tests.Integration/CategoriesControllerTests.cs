using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace MyStore.Tests.Integration
{
    public class CategoriesControllerTests : IClassFixture<StoreApiFactory<Program>>
    {
        private readonly HttpClient httpClient;
        public CategoriesControllerTests(StoreApiFactory<Program> apiFactory)
        {
            apiFactory.ClientOptions.BaseAddress = new Uri("http://localhost:/api/");
            httpClient = apiFactory.CreateClient();
        }

        [Fact]
        public async void Get_ReturnsNotFound_WhenCategoryDoesntExist()
        {
            // Arrange 

            // Act 
            var response = await httpClient.GetAsync($"" +
                $"categories/3");

            // Assert 

            response.StatusCode.Should().Be(HttpStatusCode.NotFound); 

        }
    }
}