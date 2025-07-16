using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.DTOs;
using AdventureWorksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AdventureWorksAPI.Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductRepository> __mockRepo;
        private readonly ProductsController _controller;
        public ProductsControllerTests()
        {
            __mockRepo = new Mock<IProductRepository>();
            _controller = new ProductsController(__mockRepo.Object);
        }

        [Fact]
        public async Task GetTop10_ReturnsOkResult_WithListOfProducts()
        {
            var mockProducts = new List<ProductDto>
            {
                 new ProductDto { Name = "Bike", ProductNumber = "BK-001", ListPrice = 1000 },
                new ProductDto { Name = "Helmet", ProductNumber = "HL-002", ListPrice = 200 }
            };

            __mockRepo.Setup(r => r.GetTop10ProductsAsync())
            .ReturnsAsync(mockProducts);

            var result = await _controller.GetTop10();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.Equal(2, ((List<ProductDto>)products).Count);
        }

        [Fact]
        public async Task GetTotalProductCount_ReturnsCorrectCount()
        {
            __mockRepo.Setup(r => r.GetTotalProductCountAsync()).ReturnsAsync(100);

            var result = await _controller.GetTotalProductCount();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var count = Assert.IsType<int>(okResult.Value);
            Assert.Equal(100, count);
        }
    }
}