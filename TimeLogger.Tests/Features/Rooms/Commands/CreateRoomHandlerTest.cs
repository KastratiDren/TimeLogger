using TimeLogger.Application.Features.Rooms.Commands;
using TimeLogger.Application.Features.Rooms.Dtos;

namespace TimeLogger.Application.Tests.Features.Rooms.Commands
{
    public class CreateRoomHandlerTest
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateRoomHandler _handler;

        public CreateRoomHandlerTest()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateRoomHandler(_mockRoomRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateRoomHandle_ValidRequest_CreatesRoomAndReturnsRoomDto()
        {
            // Arrange
            var roomDto = new RoomDto
            {
                Name = "Conference Room A",
                OfficeId = 1
            };

            var roomEntity = new Room
            {
                Name = "Conference Room A",
                OfficeId = 1
            };

            var createdRoomDto = new RoomDto
            {
                Name = "Conference Room A",
                OfficeId = 1
            };

            _mockMapper
                .Setup(mapper => mapper.Map<Room>(roomDto))
                .Returns(roomEntity);

            _mockMapper
                .Setup(mapper => mapper.Map<RoomDto>(roomEntity))
                .Returns(createdRoomDto);

            _mockRoomRepository
                .Setup(repo => repo.CreateRoom(roomEntity))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(new CreateRoom(roomDto), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Conference Room A", result.Name);
            Assert.Equal(1, result.OfficeId);

            _mockMapper.Verify(mapper => mapper.Map<Room>(roomDto), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<RoomDto>(roomEntity), Times.Once);
            _mockRoomRepository.Verify(repo => repo.CreateRoom(roomEntity), Times.Once);
        }
    }
}
