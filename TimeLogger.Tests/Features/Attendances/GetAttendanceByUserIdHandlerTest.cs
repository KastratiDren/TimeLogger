using TimeLogger.Application.Features.Attendances.Queries;

namespace TimeLogger.Application.Tests.Features.Attendances.Queries
{
    public class GetAttendanceByUserIdHandlerTest
    {
        private readonly Mock<IAttendanceRepository> _mockAttendanceRepository;
        private readonly GetAttendanceByUserIdHandler _handler;

        public GetAttendanceByUserIdHandlerTest()
        {
            _mockAttendanceRepository = new Mock<IAttendanceRepository>();
            _handler = new GetAttendanceByUserIdHandler(_mockAttendanceRepository.Object);
        }

        [Fact]
        public async Task GetAttendanceByUserIdHandle_WhenNoAttendance_ReturnsEmptyList()
        {
            // Arrange
            var userId = "user1";

            _mockAttendanceRepository
                .Setup(repo => repo.GetAttendancesByUserId(userId))
                .ReturnsAsync(new List<Attendance>());

            // Act
            var result = await _handler.Handle(new GetAttendanceByUserId(userId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAttendanceByUserIdHandle_WhenAttendanceExists_ReturnsCorrectList()
        {
            // Arrange
            var userId = "user1";
            var attendances = new List<Attendance>
            {
                new Attendance { OfficeName = "Office A", CheckInTime = DateTime.UtcNow, UserName = userId },
                new Attendance { OfficeName = "Office B", CheckInTime = DateTime.UtcNow.AddHours(-1), UserName = userId }
            };

            _mockAttendanceRepository
                .Setup(repo => repo.GetAttendancesByUserId(userId))
                .ReturnsAsync(attendances);

            // Act
            var result = await _handler.Handle(new GetAttendanceByUserId(userId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(attendances.Count, result.Count);
            Assert.All(result, a => Assert.Equal(userId, a.UserName));
        }
    }
}
