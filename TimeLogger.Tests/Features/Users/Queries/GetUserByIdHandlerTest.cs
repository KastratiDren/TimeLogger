using TimeLogger.Application.Features.Users.Dtos;
using TimeLogger.Application.Features.Users.Queries;

namespace TimeLogger.Application.Tests.Features.Users.Queries
{
    public class GetUserByIdHandlerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetUserByIdHandler _handler;

        public GetUserByIdHandlerTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetUserByIdHandler(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetUserByIdHandle_WhenUserExists_ReturnsMappedUserDto()
        {
            // Arrange
            var userId = "user123";
            var user = new User
            {
                Id = userId,
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@example.com"
            };

            var userDto = new ProfileDto
            {
                Id = userId,
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@example.com"
            };

            _mockUserRepository
                .Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync(user);

            _mockMapper
                .Setup(mapper => mapper.Map<ProfileDto>(user))
                .Returns(userDto);

            // Act
            var result = await _handler.Handle(new GetUserById(userId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal("John", result.Name);
            Assert.Equal("Doe", result.Surname);
            Assert.Equal("john.doe@example.com", result.Email);

            _mockUserRepository.Verify(repo => repo.GetUserById(userId), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<ProfileDto>(user), Times.Once);
        }

        [Fact]
        public async Task GetUserByIdHandle_WhenUserDoesNotExist_ThrowsKeyNotFoundException()
        {
            // Arrange
            var userId = "user123";
            _mockUserRepository
                .Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync((User?)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _handler.Handle(new GetUserById(userId), CancellationToken.None));
            Assert.Equal($"User with ID {userId} not found.", exception.Message);

            _mockUserRepository.Verify(repo => repo.GetUserById(userId), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<ProfileDto>(It.IsAny<User>()), Times.Never);
        }
    }
}
