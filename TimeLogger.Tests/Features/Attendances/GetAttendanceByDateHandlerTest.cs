using TimeLogger.Application.Features.Attendances.Queries;

namespace TimeLogger.Application.Tests.Features.Attendances.Queries
{
    public class GetAttendanceByDateHandlerTest
    {
        private readonly Mock<IAttendanceRepository> _mockAttendanceRepository;
        private readonly GetAttendanceByDateHandler _handler;

        public GetAttendanceByDateHandlerTest()
        {
            _mockAttendanceRepository = new Mock<IAttendanceRepository>();
            _handler = new GetAttendanceByDateHandler(_mockAttendanceRepository.Object);
        }

        [Fact]
        public async Task GetAttendanceByDateHandle_WhenNoAttendance_ReturnsEmptyList()
        {
            // Arrange
            var date = new DateOnly(2023, 1, 1);
            var dateTime = date.ToDateTime(TimeOnly.MinValue);

            _mockAttendanceRepository
                .Setup(repo => repo.GetAttendancesByDate(dateTime))
                .ReturnsAsync(new List<Attendance>());

            // Act
            var result = await _handler.Handle(new GetAttendanceByDate(date), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAttendanceByDateHandle_WhenAttendanceExists_ReturnsCorrectList()
        {
            // Arrange
            var date = new DateOnly(2023, 1, 1);
            var dateTime = date.ToDateTime(TimeOnly.MinValue);
            var attendances = new List<Attendance>
            {
                new Attendance { OfficeName = "Office A", CheckInTime = dateTime, UserName = "user1" },
                new Attendance { OfficeName = "Office B", CheckInTime = dateTime, UserName = "user2" }
            };

            _mockAttendanceRepository
                .Setup(repo => repo.GetAttendancesByDate(dateTime))
                .ReturnsAsync(attendances);

            // Act
            var result = await _handler.Handle(new GetAttendanceByDate(date), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(attendances.Count, result.Count);
            Assert.All(result, a => Assert.Equal(dateTime, a.CheckInTime));
        }
    }
}
