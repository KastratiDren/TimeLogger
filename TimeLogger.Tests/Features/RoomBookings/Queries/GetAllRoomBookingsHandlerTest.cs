using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.Features.RoomBookings.Queries;

namespace TimeLogger.Application.Tests.Features.RoomBookings.Queries
{
    public class GetAllRoomBookingsHandlerTest
    {
        private readonly Mock<IRoomBookingRepository> _mockRoomBookingRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetAllRoomBookingsHandler _handler;

        public GetAllRoomBookingsHandlerTest()
        {
            _mockRoomBookingRepository = new Mock<IRoomBookingRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetAllRoomBookingsHandler(_mockRoomBookingRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllRoomBookingHandle_WhenCalled_ReturnsMappedRoomBookings()
        {
            // Arrange
            var roomBookings = new List<RoomBooking>
            {
                new RoomBooking
                {
                    RoomId = 1,
                    StartTime = new DateTime(2025, 1, 30, 10, 0, 0),
                    EndTime = new DateTime(2025, 1, 30, 12, 0, 0),
                    UserId = "user123"
                },
                new RoomBooking
                {
                    RoomId = 2,
                    StartTime = new DateTime(2025, 1, 31, 14, 0, 0),
                    EndTime = new DateTime(2025, 1, 31, 16, 0, 0),
                    UserId = "user456"
                }
            };

            var roomBookingsDtos = new List<RoomBookingsDto>
            {
                new RoomBookingsDto
                {
                    RoomId = 1,
                    StartTime = new DateTime(2025, 1, 30, 10, 0, 0),
                    EndTime = new DateTime(2025, 1, 30, 12, 0, 0),
                    UserId = "user123"
                },
                new RoomBookingsDto
                {
                    RoomId = 2,
                    StartTime = new DateTime(2025, 1, 31, 14, 0, 0),
                    EndTime = new DateTime(2025, 1, 31, 16, 0, 0),
                    UserId = "user456"
                }
            };

            _mockRoomBookingRepository
                .Setup(repo => repo.GetAllRoomBookings())
                .ReturnsAsync(roomBookings); 

            _mockMapper
                .Setup(mapper => mapper.Map<IEnumerable<RoomBookingsDto>>(roomBookings))
                .Returns(roomBookingsDtos); 

            // Act
            var result = await _handler.Handle(new GetAllRoomBookings(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            var firstDto = result.First();
            Assert.Equal(1, firstDto.RoomId);
            Assert.Equal("user123", firstDto.UserId);
            Assert.Equal(new DateTime(2025, 1, 30, 10, 0, 0), firstDto.StartTime);
            Assert.Equal(new DateTime(2025, 1, 30, 12, 0, 0), firstDto.EndTime);

            var secondDto = result.Last();
            Assert.Equal(2, secondDto.RoomId);
            Assert.Equal("user456", secondDto.UserId);
            Assert.Equal(new DateTime(2025, 1, 31, 14, 0, 0), secondDto.StartTime);
            Assert.Equal(new DateTime(2025, 1, 31, 16, 0, 0), secondDto.EndTime);

            _mockRoomBookingRepository.Verify(repo => repo.GetAllRoomBookings(), Times.Once); 
            _mockMapper.Verify(mapper => mapper.Map<IEnumerable<RoomBookingsDto>>(roomBookings), Times.Once); 
        }
    }
}
