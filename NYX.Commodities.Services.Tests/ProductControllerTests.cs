using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NYX.Commodities.Services.ProductAPI.Controllers;
using NYX.Commodities.Services.ProductAPI.Models;
using NYX.Commodities.Services.ProductAPI.Models.Dtos;
using NYX.Commodities.Services.ProductAPI.Repository;
using Xunit;

namespace NYX.Commodities.Services.Tests
{
    public class ProductControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IProductsRepository> _repoMock;
        private readonly ProductAPIController _sut;
        public ProductControllerTests()
        {
            _fixture = new Fixture();
            _repoMock = _fixture.Freeze<Mock<IProductsRepository>>();
            _sut = new ProductAPIController(_repoMock.Object);
        }

        [Fact]
        public void ProductControllerConstructor_ShouldReturnNullReferenceException_WhenRepoIsNull()
        {
            // Arrange
            IProductsRepository? prodRepo = null;

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new ProductAPIController(prodRepo));
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var productListMock = _fixture.Create<IEnumerable<Product>>();
            _repoMock.Setup(x => x.GetProductsAsync()).ReturnsAsync(productListMock);

            //Act
            var result = await _sut.Get();

            //Assert
            Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(productListMock.GetType());
            _repoMock.Verify(x => x.GetProductsAsync(), Times.Once());
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnNotFound_WhenDataNotFound()
        {
            //Arrange
            IEnumerable<Product> products = null;
            _repoMock.Setup(x => x.GetProductsAsync()).ReturnsAsync(products);

            //Act
            var result = await _sut.Get();

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<NotFoundResult>();
            _repoMock.Verify(x => x.GetProductsAsync(), Times.Once());
        }

        [Fact]
        public async Task GetGetByColor_ShouldReturnOkResponse_WhenValidInput()
        {
            // Arrange
            var prodMock = _fixture.Create<Product>();
            var color = "Blue";
            _repoMock.Setup(x => x.GetProductByColorAsync(color)).ReturnsAsync(prodMock);

            // Act
            var result = await _sut.GetByColor(color);

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should()
                .NotBeNull()
                .And.BeOfType(prodMock.GetType());
            _repoMock.Verify(x => x.GetProductByColorAsync(color), Times.Once());
        }

        [Fact]
        public async Task GetGetByColor_ShouldReturnBadRequest_WhenNoDataFound()
        {
            // Arrange
            var prodMock = _fixture.Create<Product>();
            var color = "";
            _repoMock.Setup(x => x.GetProductByColorAsync(color)).ReturnsAsync(prodMock);

            // Act
            var result = await _sut.GetByColor(color);

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _repoMock.Verify(x => x.GetProductByColorAsync(color), Times.Once());
        }

        [Fact]
        public async Task GetGetByColor_ShouldReturnBadRequest_WhenInvalidInput()
        {
            // Arrange
            var prodMock = _fixture.Create<Product>();
            string color = null;
            _repoMock.Setup(x => x.GetProductByColorAsync(color)).ReturnsAsync(prodMock);

            // Act
            var result = await _sut.GetByColor(color);

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
            _repoMock.Verify(x => x.GetProductByColorAsync(color), Times.Once());
        }
    }
}