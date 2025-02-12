using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.Features.Rooms.Queries;

namespace TimeLogger.Application.Tests.Features.Rooms.Queries
{
    public class GetRoomByIdHandlerTest
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetRoomByIdHandler _handler;

        public GetRoomByIdHandlerTest()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetRoomByIdHandler(_mockRoomRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetRoomByIdHandle_WhenRoomExists_ReturnsMappedRoomDto()
        {
            // Arrange
            var room = new Room { Name = "Room A", OfficeId = 1 };
            var roomDto = new RoomDto { Name = "Room A", OfficeId = 1 };

            _mockRoomRepository
                .Setup(repo => repo.GetRoomById(It.IsAny<int>()))
                .ReturnsAsync(room);

            _mockMapper
                .Setup(mapper => mapper.Map<RoomDto>(room))
                .Returns(roomDto);

            // Act
            var result = await _handler.Handle(new GetRoomById(1), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Room A", result.Name);
            Assert.Equal(1, result.OfficeId);

            _mockRoomRepository.Verify(repo => repo.GetRoomById(1), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<RoomDto>(room), Times.Once);
        }

        [Fact]
        public async Task GetRoomByIdHandle_WhenRoomDoesNotExist_ReturnsNull()
        {
            // Arrange
            _mockRoomRepository
                .Setup(repo => repo.GetRoomById(It.IsAny<int>()))
                .ReturnsAsync((Room?)null);

            // Act
            var result = await _handler.Handle(new GetRoomById(1), CancellationToken.None);

            // Assert
            Assert.Null(result);

            _mockRoomRepository.Verify(repo => repo.GetRoomById(1), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<RoomDto>(It.IsAny<Room>()), Times.Never);
        }
    }
}
