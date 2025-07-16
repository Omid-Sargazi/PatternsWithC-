using System.Text.Json;
using AdventureWorksAPI.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AdventureWorksAPI.Tests.Integration
{
    public class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductsApiTests(WebApplicationFactory<Program> factory)
        {
            factory = factory.WithWebHostBuilder(builder => {
             builder.UseSolutionRelativeContentRoot("AdventureWorksAPI");
            });
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetTop10_ReturnsSuccessAndData()
        {
            var response = await _client.GetAsync("api/products/top10");

            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var products = JsonSerializer.Deserialize<List<ProductDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotNull(products);
            Assert.True(products.Count <= 10);
        }
    }
}