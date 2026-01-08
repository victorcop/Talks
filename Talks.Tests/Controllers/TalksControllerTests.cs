using Microsoft.AspNetCore.Mvc;
using Talks.Api.Controllers;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Tests.Controllers
{
    public class TalksControllerTests
    {
        private readonly Mock<ITalkService> _mockTalkService;
        private readonly TalksController _controller;

        public TalksControllerTests()
        {
            _mockTalkService = new Mock<ITalkService>();
            _controller = new TalksController(_mockTalkService.Object);
        }

        [Fact]
        public void Get_WhenTalksExist_ReturnsOkWithTalks()
        {
            // Arrange
            var talks = new List<TalksDTO>
            {
                new TalksDTO { TalkId = 1, Title = "Clean Architecture", Abstract = "Learn clean architecture principles" },
                new TalksDTO { TalkId = 2, Title = "ASP.NET Core", Abstract = "Build modern web APIs" }
            };

            _mockTalkService.Setup(s => s.GetTalksAsync()).Returns(talks);

            // Act
            var result = _controller.Get();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            var okResult = result.Result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(talks);
        }

        [Fact]
        public void Get_WhenNoTalksExist_ReturnsNoContent()
        {
            // Arrange
            _mockTalkService.Setup(s => s.GetTalksAsync()).Returns(new List<TalksDTO>());

            // Act
            var result = _controller.Get();

            // Assert
            result.Result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public void Get_WhenServiceReturnsNull_ReturnsNoContent()
        {
            // Arrange
            _mockTalkService.Setup(s => s.GetTalksAsync()).Returns((IEnumerable<TalksDTO>?)null);

            // Act
            var result = _controller.Get();

            // Assert
            result.Result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public void Get_CallsServiceGetTalksAsyncOnce()
        {
            // Arrange
            var talks = new List<TalksDTO> { new TalksDTO { TalkId = 1, Title = "Test", Abstract = "Test" } };
            _mockTalkService.Setup(s => s.GetTalksAsync()).Returns(talks);

            // Act
            _controller.Get();

            // Assert
            _mockTalkService.Verify(s => s.GetTalksAsync(), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void Get_ReturnsCorrectNumberOfTalks(int count)
        {
            // Arrange
            var talks = Enumerable.Range(1, count)
                .Select(i => new TalksDTO { TalkId = i, Title = $"Talk {i}", Abstract = $"Abstract {i}" })
                .ToList();

            _mockTalkService.Setup(s => s.GetTalksAsync()).Returns(talks);

            // Act
            var result = _controller.Get();

            // Assert
            if (count == 0)
            {
                result.Result.Should().BeOfType<NoContentResult>();
            }
            else
            {
                result.Result.Should().BeOfType<OkObjectResult>();
                var okResult = result.Result as OkObjectResult;
                var returnedTalks = okResult!.Value as IEnumerable<TalksDTO>;
                returnedTalks.Should().HaveCount(count);
            }
        }
    }
}
