using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MediatR;
using WineCorp.Api.Controllers;
using WineCorp.App;
using Microsoft.Extensions.Logging;
using FluentAssertions;

namespace WineCorp.Test.Controllers
{

    [TestClass]
    public class ParcelControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly VineyardsController _controller;
        private readonly Mock<ILogger<VineyardsController>> _loggerMock;

        public ParcelControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<VineyardsController>>();
            _controller = new VineyardsController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        [TestMethod]
        public async Task GetGrapeAreaAsync_ShouldReturnOkWithCorrectData()
        {
            // Arrange
            var expectedResult = new Dictionary<string, List<string>>
        {
            { "Viña Esmeralda", new List<string> { "Miguel Torres", "Carlos Ruiz" } },
            { "Bodegas Bilbaínas", new List<string> { "Ana Martín" } }
        };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetParcelVineyardsNamesWithManagersQuery>(), default))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GetGrapeAreaAsync();

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        [TestMethod]
        public async Task GetGrapeAreaAsync_ShouldReturnEmptyDictionaryWhenNoData()
        {
            // Arrange
            var expectedResult = new Dictionary<string, List<string>>();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetParcelVineyardsNamesWithManagersQuery>(), default))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GetGrapeAreaAsync();

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(expectedResult);
        }
    }

}
