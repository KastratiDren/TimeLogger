using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.Features.Offices.Queries;

namespace TimeLogger.Application.Tests.Features.Offices.Queries
{
    public class GetAllOfficesHandlerTest
    {
        private readonly Mock<IOfficeRepository> _mockOfficeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetAllOfficesHandler _handler;

        public GetAllOfficesHandlerTest()
        {
            _mockOfficeRepository = new Mock<IOfficeRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetAllOfficesHandler(_mockOfficeRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllOfficesHandle_WhenNoOfficesExist_ReturnsEmptyList()
        {
            // Arrange
            _mockOfficeRepository
                .Setup(repo => repo.GetAllOffices())
                .ReturnsAsync(new List<Office>());

            _mockMapper
                .Setup(mapper => mapper.Map<List<OfficeDto>>(It.IsAny<List<Office>>()))
                .Returns(new List<OfficeDto>());

            // Act
            var result = await _handler.Handle(new GetAllOffices(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _mockOfficeRepository.Verify(repo => repo.GetAllOffices(), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<List<OfficeDto>>(It.IsAny<List<Office>>()), Times.Once);
        }

        [Fact]
        public async Task GetAllOfficesHandle_WhenOfficesExist_ReturnsMappedOfficeDtos()
        {
            // Arrange
            var offices = new List<Office>
            {
                new Office { Name = "Office 1" },
                new Office { Name = "Office 2" }
            };

            var officeDtos = new List<OfficeDto>
            {
                new OfficeDto { Name = "Office 1" },
                new OfficeDto { Name = "Office 2" }
            };

            _mockOfficeRepository
                .Setup(repo => repo.GetAllOffices())
                .ReturnsAsync(offices);

            _mockMapper
                .Setup(mapper => mapper.Map<List<OfficeDto>>(offices))
                .Returns(officeDtos);

            // Act
            var result = await _handler.Handle(new GetAllOffices(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(officeDtos.Count, result.Count);
            Assert.Equal(officeDtos[0].Name, result[0].Name);
            Assert.Equal(officeDtos[1].Name, result[1].Name);

            _mockOfficeRepository.Verify(repo => repo.GetAllOffices(), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<List<OfficeDto>>(offices), Times.Once);
        }
    }
}
