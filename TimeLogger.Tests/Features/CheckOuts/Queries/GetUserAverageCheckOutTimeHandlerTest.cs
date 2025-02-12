using TimeLogger.Application.Features.Checkouts.Queries;

namespace TimeLogger.Application.Tests.Features.Checkouts.Queries
{
    public class GetUserAverageCheckOutTimeHandlerTests
    {
        private readonly Mock<ICheckOutRepository> _mockCheckOutRepository;
        private readonly GetUserAverageCheckOutTimeHandler _handler;

        public GetUserAverageCheckOutTimeHandlerTests()
        {
            _mockCheckOutRepository = new Mock<ICheckOutRepository>();
            _handler = new GetUserAverageCheckOutTimeHandler(_mockCheckOutRepository.Object);
        }

        [Fact]
        public async Task UserAverageCheckOutHandle_WhenNoCheckOuts_ReturnsNull()
        {
            // Arrange
            var userId = "user1";

            _mockCheckOutRepository
                .Setup(repo => repo.GetCheckOutsByUserId(userId))
                .ReturnsAsync(new List<CheckOut>());

            // Act
            var result = await _handler.Handle(new GetUserAverageCheckOutTime(userId), CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UserAverageCheckOutHandle_WhenMultipleCheckOuts_ReturnsCorrectAverage()
        {
            // Arrange
            var userId = "user1";
            var checkOuts = new List<CheckOut>
            {
                new CheckOut { CheckOutTime = new DateTime(2023, 1, 1, 17, 0, 0), UserId = userId, OfficeId = 1 },
                new CheckOut { CheckOutTime = new DateTime(2023, 1, 2, 18, 0, 0), UserId = userId, OfficeId = 1 },
                new CheckOut { CheckOutTime = new DateTime(2023, 1, 3, 16, 30, 0), UserId = userId, OfficeId = 1 }
            };

            _mockCheckOutRepository
                .Setup(repo => repo.GetCheckOutsByUserId(userId))
                .ReturnsAsync(checkOuts);

            // Act
            var result = await _handler.Handle(new GetUserAverageCheckOutTime(userId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);

            var expectedAverageTicks = (checkOuts[0].CheckOutTime.Ticks + checkOuts[1].CheckOutTime.Ticks + checkOuts[2].CheckOutTime.Ticks) / 3;
            var expectedAverage = new TimeSpan(expectedAverageTicks);

            Assert.Equal(expectedAverage, result);
        }
    }
}
