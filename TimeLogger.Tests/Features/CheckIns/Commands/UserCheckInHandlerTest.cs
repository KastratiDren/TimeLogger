using TimeLogger.Application.Features.Checkins.Commands;
using TimeLogger.Application.Features.Checkins.Dto;


namespace TimeLogger.Application.Tests.Features.Checkins.Commands
{
    public class UserCheckInHandlerTest
    {
        private readonly Mock<ICheckInRepository> _mockCheckInRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly UserCheckInHandler _handler;

        public UserCheckInHandlerTest()
        {
            _mockCheckInRepository = new Mock<ICheckInRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new UserCheckInHandler(_mockCheckInRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UserCheckInHandle_WhenCheckInAlreadyExists_ReturnsFalse()
        {
            // Arrange
            var checkInDto = new CheckInDto
            {
                OfficeId = 1,
                UserId = "user1"
            };

            var existingCheckIns = new List<CheckIn>
            {
                new CheckIn { CheckInTime = DateTime.Today, OfficeId = 1, UserId = "user1" }
            };

            _mockCheckInRepository
                .Setup(repo => repo.GetCheckInsByUserId("user1"))
                .ReturnsAsync(existingCheckIns);

            // Act
            var result = await _handler.Handle(new UserCheckIn(checkInDto), CancellationToken.None);

            // Assert
            Assert.False(result);
            _mockCheckInRepository.Verify(repo => repo.CreateCheckIn(It.IsAny<CheckIn>()), Times.Never);
        }

        [Fact]
        public async Task UserCheckInHandle_WhenCheckInDoesNotExist_CreatesCheckInAndReturnsTrue()
        {
            // Arrange
            var checkInDto = new CheckInDto
            {
                OfficeId = 1,
                UserId = "user1"
            };

            var existingCheckIns = new List<CheckIn>();

            _mockCheckInRepository
                .Setup(repo => repo.GetCheckInsByUserId("user1"))
                .ReturnsAsync(existingCheckIns);

            var checkInEntity = new CheckIn { CheckInTime = DateTime.Now, OfficeId = 1, UserId = "user1" };
            _mockMapper
                .Setup(mapper => mapper.Map<CheckIn>(checkInDto))
                .Returns(checkInEntity);

            // Act
            var result = await _handler.Handle(new UserCheckIn(checkInDto), CancellationToken.None);

            // Assert
            Assert.True(result);
            _mockCheckInRepository.Verify(repo => repo.CreateCheckIn(It.IsAny<CheckIn>()), Times.Once);
        }
    }
}
