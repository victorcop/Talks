using AutoMapper;
using Talks.Data.Repositories;
using Talks.Domain;
using Talks.Service.Models;

namespace Talks.Service.Tests
{
    public class TalkServiceTests
    {
        private readonly Mock<ITalkRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TalkService _sut;

        public TalkServiceTests()
        {
            _mockRepository = new Mock<ITalkRepository>();
            _mockMapper = new Mock<IMapper>();
            _sut = new TalkService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public void GetTalksAsync_WhenTalksExist_ReturnsMappedTalksDTOs()
        {
            // Arrange
            var talks = new List<Talk>
            {
                new Talk { TalkId = 1, Title = "Clean Architecture", Abstract = "Learn clean architecture principles", Level = 2, SpeakerId = 1 },
                new Talk { TalkId = 2, Title = "ASP.NET Core", Abstract = "Build modern web APIs", Level = 1, SpeakerId = 2 }
            };

            var talksDTO = new List<TalksDTO>
            {
                new TalksDTO { TalkId = 1, Title = "Clean Architecture", Abstract = "Learn clean architecture principles" },
                new TalksDTO { TalkId = 2, Title = "ASP.NET Core", Abstract = "Build modern web APIs" }
            };

            _mockRepository.Setup(r => r.GetTalksAsync()).Returns(talks);
            _mockMapper.Setup(m => m.Map<IEnumerable<TalksDTO>>(talks)).Returns(talksDTO);

            // Act
            var result = _sut.GetTalksAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(talksDTO);
            _mockRepository.Verify(r => r.GetTalksAsync(), Times.Once);
            _mockMapper.Verify(m => m.Map<IEnumerable<TalksDTO>>(talks), Times.Once);
        }

        [Fact]
        public void GetTalksAsync_WhenNoTalksExist_ReturnsEmptyCollection()
        {
            // Arrange
            var emptyTalks = new List<Talk>();
            var emptyDTOs = new List<TalksDTO>();

            _mockRepository.Setup(r => r.GetTalksAsync()).Returns(emptyTalks);
            _mockMapper.Setup(m => m.Map<IEnumerable<TalksDTO>>(emptyTalks)).Returns(emptyDTOs);

            // Act
            var result = _sut.GetTalksAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void GetTalksAsync_VerifiesRepositoryIsCalled()
        {
            // Arrange
            var talks = new List<Talk>();
            _mockRepository.Setup(r => r.GetTalksAsync()).Returns(talks);
            _mockMapper.Setup(m => m.Map<IEnumerable<TalksDTO>>(talks)).Returns(new List<TalksDTO>());

            // Act
            _sut.GetTalksAsync();

            // Assert
            _mockRepository.Verify(r => r.GetTalksAsync(), Times.Once);
        }
    }
}
