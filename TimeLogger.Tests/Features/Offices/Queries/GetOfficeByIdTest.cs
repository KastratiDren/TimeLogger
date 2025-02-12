using TimeLogger.Application.Features.Offices.Dtos;
using TimeLogger.Application.Features.Offices.Queries;

namespace TimeLogger.Application.Tests.Features.Offices.Queries
{
    public class GetOfficeByIdHandlerTest
    {
        private readonly Mock<IOfficeRepository> _mockOfficeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetOfficeByIdHandler _handler;

        public GetOfficeByIdHandlerTest()
        {
            _mockOfficeRepository = new Mock<IOfficeRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetOfficeByIdHandler(_mockOfficeRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetOfficeByIdHandle_WhenOfficeExists_ReturnsOfficeDto()
        {
            // Arrange
            var officeId = 1;

            var officeEntity = new Office
            {
                Name = "Office A"
            };

            var officeDto = new OfficeDto
            {
                Name = "Office A"
            };

            _mockOfficeRepository
                .Setup(repo => repo.GetOfficeById(officeId))
                .ReturnsAsync(officeEntity);

            _mockMapper
                .Setup(mapper => mapper.Map<OfficeDto>(officeEntity))
                .Returns(officeDto);

            // Act
            var result = await _handler.Handle(new GetOfficeById(officeId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Office A", result.Name);

            _mockOfficeRepository.Verify(repo => repo.GetOfficeById(officeId), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<OfficeDto>(officeEntity), Times.Once);
        }

        [Fact]
        public async Task GetOfficeByIdHandle_WhenOfficeDoesNotExist_ReturnsNull()
        {
            // Arrange
            var officeId = 1;

            _mockOfficeRepository
                .Setup(repo => repo.GetOfficeById(officeId))
                .ReturnsAsync((Office)null);

            // Act
            var result = await _handler.Handle(new GetOfficeById(officeId), CancellationToken.None);

            // Assert
            Assert.Null(result);

            _mockOfficeRepository.Verify(repo => repo.GetOfficeById(officeId), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<OfficeDto>(It.IsAny<Office>()), Times.Never);
        }
    }
}
