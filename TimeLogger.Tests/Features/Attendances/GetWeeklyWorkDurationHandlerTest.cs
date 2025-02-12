using TimeLogger.Application.Features.Attendances.Queries;

namespace TimeLogger.Application.Tests.Features.Attendances.Queries
{
    public class GetWeeklyWorkDurationHandlerTest
    {
        private readonly Mock<IAttendanceRepository> _mockAttendanceRepository;
        private readonly GetWeeklyWorkDurationHandler _handler;

        public GetWeeklyWorkDurationHandlerTest()
        {
            _mockAttendanceRepository = new Mock<IAttendanceRepository>();
            _handler = new GetWeeklyWorkDurationHandler(_mockAttendanceRepository.Object);
        }

        [Fact]
        public async Task GetWeeklyWorkHoursHandle_WhenNoWorkHours_ReturnsZero()
        {
            // Arrange
            var userId = "user1";
            var expectedWorkDuration = TimeSpan.Zero;

            _mockAttendanceRepository
                .Setup(repo => repo.GetTotalWorkDurationByUserId(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(expectedWorkDuration);

            // Act
            var result = await _handler.Handle(new GetWeeklyWorkDuration(userId), CancellationToken.None);

            // Assert
            Assert.Equal(expectedWorkDuration, result);
        }

        [Fact]
        public async Task GetWeeklyWorkHoursHandle_WhenWorkHoursExist_ReturnsCorrectTimeSpan()
        {
            // Arrange
            var userId = "user1";
            var expectedWorkDuration = TimeSpan.FromHours(40);

            _mockAttendanceRepository
                .Setup(repo => repo.GetTotalWorkDurationByUserId(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(expectedWorkDuration);

            // Act
            var result = await _handler.Handle(new GetWeeklyWorkDuration(userId), CancellationToken.None);

            // Assert
            Assert.Equal(expectedWorkDuration, result);
        }
    }
}
