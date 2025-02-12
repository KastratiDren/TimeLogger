using TimeLogger.Application.Features.Offices.Commands;
using TimeLogger.Application.Features.Offices.Dtos;

namespace TimeLogger.Application.Tests.Features.Offices.Commands
{
    public class CreateOfficeHandlerTest
    {
        private readonly Mock<IOfficeRepository> _mockOfficeRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateOfficeHandler _handler;

        public CreateOfficeHandlerTest()
        {
            _mockOfficeRepository = new Mock<IOfficeRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateOfficeHandler(_mockOfficeRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_CreatesOfficeAndReturnsDto()
        {
            // Arrange
            var officeDto = new OfficeDto
            {
                Name = "Test Office"
            };

            var officeEntity = new Office
            {
                Name = "Test Office"
            };

            // Map from DTO to Entity
            _mockMapper
                .Setup(mapper => mapper.Map<Office>(officeDto))
                .Returns(officeEntity);

            // Map from Entity to DTO
            _mockMapper
                .Setup(mapper => mapper.Map<OfficeDto>(officeEntity))
                .Returns(officeDto);

            _mockOfficeRepository
                .Setup(repo => repo.CreateOffice(It.IsAny<Office>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(new CreateOffice(officeDto), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(officeDto.Name, result.Name);

            _mockMapper.Verify(mapper => mapper.Map<Office>(officeDto), Times.Once);
            _mockOfficeRepository.Verify(repo => repo.CreateOffice(It.Is<Office>(o => o.Name == officeEntity.Name)), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<OfficeDto>(officeEntity), Times.Once);
        }
    }
}
