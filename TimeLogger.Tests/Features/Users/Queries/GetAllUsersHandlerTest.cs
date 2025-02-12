using TimeLogger.Application.Features.Users.Dtos;
using TimeLogger.Application.Features.Users.Queries;

namespace TimeLogger.Application.Tests.Features.Users.Queries
{
    public class GetAllUsersHandlerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetAllUsersHandler _handler;

        public GetAllUsersHandlerTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetAllUsersHandler(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllUsersHandle_WhenUsersExist_ReturnsMappedUserDtos()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = "user1", Name = "John", Surname = "Doe", Email = "john.doe@example.com" },
                new User { Id = "user2", Name = "Jane", Surname = "Doe", Email = "jane.doe@example.com" }
            };

            var userDtos = new List<ProfileDto>
            {
                new ProfileDto { Id = "user1", Name = "John", Surname = "Doe", Email = "john.doe@example.com" },
                new ProfileDto { Id = "user2", Name = "Jane", Surname = "Doe", Email = "jane.doe@example.com" }
            };

            _mockUserRepository
                .Setup(repo => repo.GetAllUsers())
                .ReturnsAsync(users);

            _mockMapper
                .Setup(mapper => mapper.Map<List<ProfileDto>>(users))
                .Returns(userDtos);

            // Act
            var result = await _handler.Handle(new GetAllUsers(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].Name);
            Assert.Equal("Jane", result[1].Name);

            _mockUserRepository.Verify(repo => repo.GetAllUsers(), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<List<ProfileDto>>(users), Times.Once);
        }

        [Fact]
        public async Task GetAllUsersHandle_WhenNoUsersExist_ReturnsEmptyList()
        {
            // Arrange
            var emptyUsers = new List<User>();
            var emptyUserDtos = new List<ProfileDto>();

            _mockUserRepository
                .Setup(repo => repo.GetAllUsers())
                .ReturnsAsync(emptyUsers);

            _mockMapper
                .Setup(mapper => mapper.Map<List<ProfileDto>>(emptyUsers))
                .Returns(emptyUserDtos);

            // Act
            var result = await _handler.Handle(new GetAllUsers(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);

            _mockUserRepository.Verify(repo => repo.GetAllUsers(), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<List<ProfileDto>>(emptyUsers), Times.Once);
        }
    }
}
