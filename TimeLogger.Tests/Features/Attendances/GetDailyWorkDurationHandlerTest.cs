using TimeLogger.Application.Features.Attendances.Queries;

namespace TimeLogger.Application.Tests.Features.Attendances.Queries
{
    public class GetDailyWorkDurationHandlerTest
    {
        private readonly Mock<IAttendanceRepository> _mockAttendanceRepository;
        private readonly GetDailyWorkDurationHandler _handler;

        public GetDailyWorkDurationHandlerTest()
        {
            _mockAttendanceRepository = new Mock<IAttendanceRepository>();
            _handler = new GetDailyWorkDurationHandler(_mockAttendanceRepository.Object);
        }

        [Fact]
        public async Task GetDailyWorkHoursHandle_WhenNoWorkHours_ReturnsNull()
        {
            // Arrange
            var userId = "user1";

            _mockAttendanceRepository
                .Setup(repo => repo.GetTotalWorkDurationByUserId(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync((TimeSpan?)null);

            // Act
            var result = await _handler.Handle(new GetDailyWorkDuration(userId), CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetDailyWorkHoursHandle_WhenWorkHoursExist_ReturnsCorrectTimeSpan()
        {
            // Arrange
            var userId = "user1";
            var expectedWorkDuration = TimeSpan.FromHours(8);

            _mockAttendanceRepository
                .Setup(repo => repo.GetTotalWorkDurationByUserId(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync((TimeSpan?)expectedWorkDuration);

            // Act
            var result = await _handler.Handle(new GetDailyWorkDuration(userId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedWorkDuration, result);
        }
    }
}