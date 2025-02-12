using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.Features.RoomBookings.Queries;

namespace TimeLogger.Application.Tests.Features.RoomBookings.Queries
{
    public class GetRoomBookingsByRoomIdHandlerTest
    {
        private readonly Mock<IRoomBookingRepository> _mockRoomBookingRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetRoomBookingsByRoomIdHandler _handler;

        public GetRoomBookingsByRoomIdHandlerTest()
        {
            _mockRoomBookingRepository = new Mock<IRoomBookingRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetRoomBookingsByRoomIdHandler(_mockRoomBookingRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetRoomBookingByRoomIdHandle_WhenRoomBookingsExist_ReturnsMappedRoomBookings()
        {
            // Arrange
            int roomId = 1;

            var roomBookings = new List<RoomBooking>
            {
                new RoomBooking
                {
                    RoomId = roomId,
                    StartTime = new DateTime(2025, 2, 1, 9, 0, 0),
                    EndTime = new DateTime(2025, 2, 1, 11, 0, 0),
                    UserId = "user123"
                },
                new RoomBooking
                {
                    RoomId = roomId,
                    StartTime = new DateTime(2025, 2, 1, 12, 0, 0),
                    EndTime = new DateTime(2025, 2, 1, 14, 0, 0),
                    UserId = "user456"
                }
            };

            var roomBookingDtos = new List<RoomBookingsDto>
            {
                new RoomBookingsDto
                {
                    RoomId = roomId,
                    StartTime = new DateTime(2025, 2, 1, 9, 0, 0),
                    EndTime = new DateTime(2025, 2, 1, 11, 0, 0),
                    UserId = "user123"
                },
                new RoomBookingsDto
                {
                    RoomId = roomId,
                    StartTime = new DateTime(2025, 2, 1, 12, 0, 0),
                    EndTime = new DateTime(2025, 2, 1, 14, 0, 0),
                    UserId = "user456"
                }
            };

            _mockRoomBookingRepository
                .Setup(repo => repo.GetRoomBookingByRoomId(roomId, null))
                .ReturnsAsync(roomBookings);

            _mockMapper
                .Setup(mapper => mapper.Map<IEnumerable<RoomBookingsDto>>(roomBookings))
                .Returns(roomBookingDtos);

            // Act
            var result = await _handler.Handle(new GetRoomBookingsByRoomId(roomId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            var firstBooking = result.First();
            Assert.Equal(roomId, firstBooking.RoomId);
            Assert.Equal("user123", firstBooking.UserId);
            Assert.Equal(new DateTime(2025, 2, 1, 9, 0, 0), firstBooking.StartTime);
            Assert.Equal(new DateTime(2025, 2, 1, 11, 0, 0), firstBooking.EndTime);

            var secondBooking = result.Last();
            Assert.Equal(roomId, secondBooking.RoomId);
            Assert.Equal("user456", secondBooking.UserId);
            Assert.Equal(new DateTime(2025, 2, 1, 12, 0, 0), secondBooking.StartTime);
            Assert.Equal(new DateTime(2025, 2, 1, 14, 0, 0), secondBooking.EndTime);

            _mockRoomBookingRepository.Verify(repo => repo.GetRoomBookingByRoomId(roomId, null), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<RoomBookingsDto>>(roomBookings), Times.Once);
        }

        [Fact]
        public async Task GetRoomBookingByRoomIdHandle_WhenNoRoomBookingsExist_ReturnsEmptyList()
        {
            // Arrange
            int roomId = 1;

            _mockRoomBookingRepository
                .Setup(repo => repo.GetRoomBookingByRoomId(roomId, null))
                .ReturnsAsync(new List<RoomBooking>());

            _mockMapper
                .Setup(mapper => mapper.Map<IEnumerable<RoomBookingsDto>>(It.IsAny<IEnumerable<RoomBooking>>()))
                .Returns(new List<RoomBookingsDto>());

            // Act
            var result = await _handler.Handle(new GetRoomBookingsByRoomId(roomId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);

            _mockRoomBookingRepository.Verify(repo => repo.GetRoomBookingByRoomId(roomId, null), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<RoomBookingsDto>>(It.IsAny<IEnumerable<RoomBooking>>()), Times.Once);
        }

        [Fact]
        public async Task GetRoomBookingByRoomIdHandle_WhenRepositoryThrowsException_PropagatesException()
        {
            // Arrange
            int roomId = 1;

            _mockRoomBookingRepository
                .Setup(repo => repo.GetRoomBookingByRoomId(roomId, null))
                .ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(new GetRoomBookingsByRoomId(roomId), CancellationToken.None));
            Assert.Equal("Database error", exception.Message);

            _mockRoomBookingRepository.Verify(repo => repo.GetRoomBookingByRoomId(roomId, null), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<RoomBookingsDto>>(It.IsAny<IEnumerable<RoomBooking>>()), Times.Never);
        }
    }
}
