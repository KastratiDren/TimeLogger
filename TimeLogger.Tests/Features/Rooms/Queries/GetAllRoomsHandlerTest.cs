using TimeLogger.Application.Features.Rooms.Dtos;
using TimeLogger.Application.Features.Rooms.Queries;

namespace TimeLogger.Application.Tests.Features.Rooms.Queries
{
    public class GetAllRoomsHandlerTest
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetAllRoomsHandler _handler;

        public GetAllRoomsHandlerTest()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetAllRoomsHandler(_mockRoomRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllRoomsHandle_WhenRoomsExist_ReturnsMappedRoomDtos()
        {
            // Arrange
            var rooms = new List<Room>
            {
                new Room { Name = "Room A", OfficeId = 1 },
                new Room { Name = "Room B", OfficeId = 2 }
            };

            var roomDtos = new List<RoomDto>
            {
                new RoomDto { Name = "Room A", OfficeId = 1 },
                new RoomDto { Name = "Room B", OfficeId = 2 }
            };

            _mockRoomRepository
                .Setup(repo => repo.GetAllRooms())
                .ReturnsAsync(rooms);

            _mockMapper
                .Setup(mapper => mapper.Map<IEnumerable<RoomDto>>(rooms))
                .Returns(roomDtos);

            // Act
            var result = await _handler.Handle(new GetAllRooms(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            var resultList = result.ToList();
            Assert.Equal("Room A", resultList[0].Name);
            Assert.Equal(1, resultList[0].OfficeId);
            Assert.Equal("Room B", resultList[1].Name);
            Assert.Equal(2, resultList[1].OfficeId);

            _mockRoomRepository.Verify(repo => repo.GetAllRooms(), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<RoomDto>>(rooms), Times.Once);
        }

        [Fact]
        public async Task GetAllRoomsHandle_WhenNoRoomsExist_ReturnsEmptyList()
        {
            // Arrange
            var emptyRooms = new List<Room>();
            var emptyRoomDtos = new List<RoomDto>();

            _mockRoomRepository
                .Setup(repo => repo.GetAllRooms())
                .ReturnsAsync(emptyRooms);

            _mockMapper
                .Setup(mapper => mapper.Map<IEnumerable<RoomDto>>(emptyRooms))
                .Returns(emptyRoomDtos);

            // Act
            var result = await _handler.Handle(new GetAllRooms(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);

            _mockRoomRepository.Verify(repo => repo.GetAllRooms(), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<RoomDto>>(emptyRooms), Times.Once);
        }
    }
}
