using TimeLogger.Application.Features.Checkins.Queries;

namespace TimeLogger.Application.Tests.Features.Checkins.Queries
{
    public class GetUserAverageCheckInTimeHandlerTest
    {
        private readonly Mock<ICheckInRepository> _mockCheckInRepository;
        private readonly GetUserAverageCheckInTimeHandler _handler;

        public GetUserAverageCheckInTimeHandlerTest()
        {
            _mockCheckInRepository = new Mock<ICheckInRepository>();
            _handler = new GetUserAverageCheckInTimeHandler(_mockCheckInRepository.Object);
        }

        [Fact]
        public async Task UserAverageCheckInHandle_WhenNoCheckIns_ReturnsNull()
        {
            // Arrange
            var userId = "user1";

            _mockCheckInRepository
                .Setup(repo => repo.GetCheckInsByUserId(userId))
                .ReturnsAsync(new List<CheckIn>());

            // Act
            var result = await _handler.Handle(new GetUserAverageCheckInTime(userId), CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UserAverageCheckInHandle_WhenMultipleCheckIns_ReturnsCorrectAverage()
        {
            // Arrange
            var userId = "user1";
            var checkIns = new List<CheckIn>
            {
                new CheckIn { CheckInTime = new DateTime(2023, 1, 1, 8, 0, 0), UserId = userId, OfficeId = 1 },
                new CheckIn { CheckInTime = new DateTime(2023, 1, 2, 9, 0, 0), UserId = userId, OfficeId = 1 },
                new CheckIn { CheckInTime = new DateTime(2023, 1, 3, 7, 30, 0), UserId = userId, OfficeId = 1 }
            };

            _mockCheckInRepository
                .Setup(repo => repo.GetCheckInsByUserId(userId))
                .ReturnsAsync(checkIns);

            // Act
            var result = await _handler.Handle(new GetUserAverageCheckInTime(userId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);

            var expectedAverageTicks = (checkIns[0].CheckInTime.Ticks + checkIns[1].CheckInTime.Ticks + checkIns[2].CheckInTime.Ticks) / 3;
            var expectedAverage = new TimeSpan(expectedAverageTicks);

            Assert.Equal(expectedAverage, result);
        }

    }
}
