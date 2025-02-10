using TimeLogger.Application.Features.Checkouts.Commands;
using TimeLogger.Application.Features.Checkouts.Dtos;

namespace TimeLogger.Application.Tests.Features.Checkouts.Commands
{
    public class UserCheckOutHandlerTest
    {
        private readonly Mock<ICheckInRepository> _mockCheckInRepository;
        private readonly Mock<ICheckOutRepository> _mockCheckOutRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserCheckOutHandler _handler;

        public UserCheckOutHandlerTest()
        {
            _mockCheckInRepository = new Mock<ICheckInRepository>();
            _mockCheckOutRepository = new Mock<ICheckOutRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new UserCheckOutHandler(
                _mockCheckInRepository.Object,
                _mockCheckOutRepository.Object,
                _mockMapper.Object);
        }

        [Fact]
        public async Task UserCheckOutHandle_WhenNoCheckInExistsForToday_ReturnsFalse()
        {
            // Arrange
            var checkOutDto = new CheckOutDto
            {
                OfficeId = 1,
                UserId = "user1"
            };

            _mockCheckInRepository
                .Setup(repo => repo.GetCheckInsByUserId("user1"))
                .ReturnsAsync(new List<CheckIn>()); 

            // Act
            var result = await _handler.Handle(new UserCheckOut(checkOutDto), CancellationToken.None);

            // Assert
            Assert.False(result);
            _mockCheckOutRepository.Verify(repo => repo.CreateCheckOut(It.IsAny<CheckOut>()), Times.Never);
        }

        [Fact]
        public async Task UserCheckOutHandle_WhenCheckOutAlreadyExistsForToday_ReturnsFalse()
        {
            // Arrange
            var checkOutDto = new CheckOutDto
            {
                OfficeId = 1,
                UserId = "user1"
            };

            var existingCheckIns = new List<CheckIn>
            {
                new CheckIn { CheckInTime = DateTime.Today, OfficeId = 1, UserId = "user1" }
            };

            var existingCheckOuts = new List<CheckOut>
            {
                new CheckOut { CheckOutTime = DateTime.Today, OfficeId = 1, UserId = "user1" }
            };

            _mockCheckInRepository
                .Setup(repo => repo.GetCheckInsByUserId("user1"))
                .ReturnsAsync(existingCheckIns);

            _mockCheckOutRepository
                .Setup(repo => repo.GetCheckOutsByUserId("user1"))
                .ReturnsAsync(existingCheckOuts);

            // Act
            var result = await _handler.Handle(new UserCheckOut(checkOutDto), CancellationToken.None);

            // Assert
            Assert.False(result);
            _mockCheckOutRepository.Verify(repo => repo.CreateCheckOut(It.IsAny<CheckOut>()), Times.Never);
        }

        [Fact]
        public async Task UserCheckOutHandle_WhenCheckOutIsValid_CreatesCheckOutAndReturnsTrue()
        {
            // Arrange
            var checkOutDto = new CheckOutDto
            {
                OfficeId = 1,
                UserId = "user1"
            };

            var existingCheckIns = new List<CheckIn>
            {
                new CheckIn { CheckInTime = DateTime.Today, OfficeId = 1, UserId = "user1" }
            };

            var existingCheckOuts = new List<CheckOut>(); // No checkouts for today

            _mockCheckInRepository
                .Setup(repo => repo.GetCheckInsByUserId("user1"))
                .ReturnsAsync(existingCheckIns);

            _mockCheckOutRepository
                .Setup(repo => repo.GetCheckOutsByUserId("user1"))
                .ReturnsAsync(existingCheckOuts);

            var checkOutEntity = new CheckOut { CheckOutTime = DateTime.Now, OfficeId = 1, UserId = "user1" };
            _mockMapper
                .Setup(mapper => mapper.Map<CheckOut>(checkOutDto))
                .Returns(checkOutEntity);

            // Act
            var result = await _handler.Handle(new UserCheckOut(checkOutDto), CancellationToken.None);

            // Assert
            Assert.True(result);
            _mockCheckOutRepository.Verify(repo => repo.CreateCheckOut(It.IsAny<CheckOut>()), Times.Once);
        }
    }
}
