using TimeLogger.Application.Features.Attendances.Queries;

namespace TimeLogger.Application.Tests.Features.Attendances.Queries
{
    public class GetMonthlyWorkDurationHandlerTest
    {
        private readonly Mock<IAttendanceRepository> _mockAttendanceRepository;
        private readonly GetMonthlyWorkDurationHandler _handler;

        public GetMonthlyWorkDurationHandlerTest()
        {
            _mockAttendanceRepository = new Mock<IAttendanceRepository>();
            _handler = new GetMonthlyWorkDurationHandler(_mockAttendanceRepository.Object);
        }

        [Fact]
        public async Task GetMonthlyWorkDurationHandle_WhenNoWorkHours_ReturnsZero()
        {
            // Arrange
            var userId = "user1";
            var expectedWorkDuration = TimeSpan.Zero;

            _mockAttendanceRepository
                .Setup(repo => repo.GetTotalWorkDurationByUserId(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(expectedWorkDuration);

            // Act
            var result = await _handler.Handle(new GetMonthlyWorkDuration(userId), CancellationToken.None); // Fixed this line

            // Assert
            Assert.Equal(expectedWorkDuration, result);
        }

        [Fact]
        public async Task GetMonthlyWorkDurationHandle_WhenWorkHoursExist_ReturnsCorrectTimeSpan()
        {
            // Arrange
            var userId = "user1";
            var expectedWorkDuration = TimeSpan.FromHours(160);

            _mockAttendanceRepository
                .Setup(repo => repo.GetTotalWorkDurationByUserId(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(expectedWorkDuration);

            // Act
            var result = await _handler.Handle(new GetMonthlyWorkDuration(userId), CancellationToken.None); // Fixed this line

            // Assert
            Assert.Equal(expectedWorkDuration, result);
        }
    }
}
