using TimeLogger.Application.Features.Users.Commands;

namespace TimeLogger.Application.Tests.Features.Users.Commands
{
    public class DeleteUserHandlerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly DeleteUserHandler _handler;

        public DeleteUserHandlerTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new DeleteUserHandler(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteUserHandle_ValidUserId_DeletesUserAndReturnsTrue()
        {
            // Arrange
            var userId = "user123";
            _mockUserRepository
                .Setup(repo => repo.DeleteUser(userId))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(new DeleteUser(userId), CancellationToken.None);

            // Assert
            Assert.True(result);

            _mockUserRepository.Verify(repo => repo.DeleteUser(userId), Times.Once);
        }

        [Fact]
        public async Task DeleteUserHandle_InvalidUserId_ReturnsFalse()
        {
            // Arrange
            var userId = "user123";
            _mockUserRepository
                .Setup(repo => repo.DeleteUser(userId))
                .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(new DeleteUser(userId), CancellationToken.None);

            // Assert
            Assert.False(result);

            _mockUserRepository.Verify(repo => repo.DeleteUser(userId), Times.Once);
        }
    }
}
