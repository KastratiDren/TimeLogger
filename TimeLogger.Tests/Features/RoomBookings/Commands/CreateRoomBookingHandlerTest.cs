using TimeLogger.Application.Features.RoomBookings.Commands;
using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.Features.RoomBookings.Handlers;

namespace TimeLogger.Application.Tests.Features.RoomBookings.Commands
{
    public class CreateRoomBookingHandlerTest
    {
        private readonly Mock<IRoomBookingRepository> _mockRoomBookingRepository;
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateRoomBookingHandler _handler;

        public CreateRoomBookingHandlerTest()
        {
            _mockRoomBookingRepository = new Mock<IRoomBookingRepository>();
            _mockRoomRepository = new Mock<IRoomRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateRoomBookingHandler(_mockRoomBookingRepository.Object, _mockRoomRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateRoomBookingHandle_WhenRoomExistsAndNoConflict_ReturnsTrue()
        {
            // Arrange
            var roomBookingDto = new RoomBookingsDto
            {
                RoomId = 1,
                StartTime = new DateTime(2025, 1, 30, 10, 0, 0),
                EndTime = new DateTime(2025, 1, 30, 12, 0, 0),
                UserId = "user123"
            };

            var roomBookingEntity = new RoomBooking
            {
                RoomId = 1,
                StartTime = roomBookingDto.StartTime,
                EndTime = roomBookingDto.EndTime,
                UserId = roomBookingDto.UserId
            };

            _mockRoomRepository
                .Setup(repo => repo.IsRoomValid(roomBookingDto.RoomId))
                .ReturnsAsync(true);  

            _mockRoomBookingRepository
                .Setup(repo => repo.GetRoomBookingByRoomId(roomBookingDto.RoomId, null))
                .ReturnsAsync(new List<RoomBooking>());  

            _mockMapper
                .Setup(mapper => mapper.Map<RoomBooking>(roomBookingDto))
                .Returns(roomBookingEntity);

            _mockRoomBookingRepository
                .Setup(repo => repo.CreateRoomBooking(roomBookingEntity))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(new CreateRoomBooking(roomBookingDto), CancellationToken.None);

            // Assert
            Assert.True(result);

            _mockRoomRepository.Verify(repo => repo.IsRoomValid(roomBookingDto.RoomId), Times.Once);
            _mockRoomBookingRepository.Verify(repo => repo.GetRoomBookingByRoomId(roomBookingDto.RoomId, null), Times.Once);  // Ensures method is called with the roomId
            _mockMapper.Verify(mapper => mapper.Map<RoomBooking>(roomBookingDto), Times.Once);
            _mockRoomBookingRepository.Verify(repo => repo.CreateRoomBooking(roomBookingEntity), Times.Once);
        }

        [Fact]
        public async Task CreateRoomBookingHandle_WhenRoomDoesNotExist_ThrowsArgumentException()
        {
            // Arrange
            var roomBookingDto = new RoomBookingsDto
            {
                RoomId = 1,
                StartTime = new DateTime(2025, 1, 30, 10, 0, 0),
                EndTime = new DateTime(2025, 1, 30, 12, 0, 0),
                UserId = "user123"
            };

            _mockRoomRepository
                .Setup(repo => repo.IsRoomValid(roomBookingDto.RoomId))
                .ReturnsAsync(false);  

            // Act 
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(new CreateRoomBooking(roomBookingDto), CancellationToken.None));

            //Assert
            Assert.Equal($"Room with ID {roomBookingDto.RoomId} does not exist.", exception.Message);

            _mockRoomRepository.Verify(repo => repo.IsRoomValid(roomBookingDto.RoomId), Times.Once);
            _mockRoomBookingRepository.Verify(repo => repo.GetRoomBookingByRoomId(It.IsAny<int>(), It.IsAny<DateTime?>()), Times.Never);  
            _mockMapper.Verify(mapper => mapper.Map<RoomBooking>(It.IsAny<RoomBookingsDto>()), Times.Never);  
            _mockRoomBookingRepository.Verify(repo => repo.CreateRoomBooking(It.IsAny<RoomBooking>()), Times.Never);  
        }

        [Fact]
        public async Task CreateRoomBookingHandle_WhenRoomBookingConflicts_ThrowsInvalidOperationException()
        {
            // Arrange
            var roomBookingDto = new RoomBookingsDto
            {
                RoomId = 1,
                StartTime = new DateTime(2025, 1, 30, 10, 0, 0),
                EndTime = new DateTime(2025, 1, 30, 12, 0, 0),
                UserId = "user123"
            };

            var existingBookings = new List<RoomBooking>
            {
                new RoomBooking
                {
                    RoomId = 1,
                    StartTime = new DateTime(2025, 1, 30, 9, 0, 0),
                    EndTime = new DateTime(2025, 1, 30, 11, 0, 0),
                    UserId = "user456"
                }
            };

            _mockRoomRepository
                .Setup(repo => repo.IsRoomValid(roomBookingDto.RoomId))
                .ReturnsAsync(true);  

            _mockRoomBookingRepository
                .Setup(repo => repo.GetRoomBookingByRoomId(roomBookingDto.RoomId, null))
                .ReturnsAsync(existingBookings);  

            // Act 
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(new CreateRoomBooking(roomBookingDto), CancellationToken.None));
            
            //Assert
            Assert.Equal("The room is already booked for the specified timeframe.", exception.Message);

            _mockRoomRepository.Verify(repo => repo.IsRoomValid(roomBookingDto.RoomId), Times.Once);
            _mockRoomBookingRepository.Verify(repo => repo.GetRoomBookingByRoomId(roomBookingDto.RoomId, null), Times.Once);  
            _mockMapper.Verify(mapper => mapper.Map<RoomBooking>(roomBookingDto), Times.Never);  
            _mockRoomBookingRepository.Verify(repo => repo.CreateRoomBooking(It.IsAny<RoomBooking>()), Times.Never);  
        }
    }
}
