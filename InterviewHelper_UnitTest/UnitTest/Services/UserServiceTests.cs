using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.services.IServices;
using intervirew_helper_backend.services;
using intervirew_helper_backend.Repository;
using intervirew_helper_backend.Repository.IRepository.intervirew_helper_backend.Repository.IRepository;

namespace InterviewHelper.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        // ==================== IsUserExist Tests ====================

        [Test]
        public async Task IsUserExist_UserExists_ReturnsTrue()
        {
            // Arrange
            var userName = "existingUser";
            _userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(userName))
                               .ReturnsAsync(new User { UserName = userName });

            // Act
            var result = await _userService.IsUserExist(userName);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsUserExist_UserDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var userName = "nonExistingUser";
            _userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(userName))
                               .ReturnsAsync((User)null);

            // Act
            var result = await _userService.IsUserExist(userName);

            // Assert
            Assert.IsFalse(result);
        }

        // ==================== AddUser Tests ====================

        [Test]
        public async Task AddUser_ValidUser_AddsUserSuccessfully()
        {
            // Arrange
            var user = new User { UserName = "newUser", UserPassword = "password123", IsActive = true };
            _userRepositoryMock.Setup(repo => repo.AddUser(user)).Returns(Task.CompletedTask);

            // Act
            await _userService.AddUser(user);

            // Assert
            _userRepositoryMock.Verify(repo => repo.AddUser(user), Times.Once);
        }

        // ==================== ValidateUser Tests ====================

        [Test]
        public async Task ValidateUser_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var userName = "validUser";
            var plainPassword = "password123";  // Original password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);  // Hash it once

            // Create a mock user with the hashed password
            var user = new User
            {
                UserName = userName,
                UserPassword = hashedPassword,
                IsActive = true
            };

            // Setup the repository mock to return the mock user
            _userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(userName))
                               .ReturnsAsync(user);

            // Act: Validate with the correct credentials
            var result = await _userService.ValidateUser(userName, plainPassword);  // Same password

            // Assert: Should return the user object
            Assert.IsNotNull(result);
            Assert.AreEqual(user.UserName, result.UserName);
            Assert.AreEqual(user.UserPassword, result.UserPassword);

        }

        [Test]
        public async Task ValidateUser_InvalidPassword_ReturnsNull()
        {  // Arrange
            var userName = "validUser";
            var correctPassword = "password123"; // Plain text password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(correctPassword); // Hash it once

            // Mock user with the hashed password
            var user = new User
            {
                UserName = userName,
                UserPassword = hashedPassword,
                IsActive = true
            };

            // Setup mock repository to return the user
            _userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(userName))
                               .ReturnsAsync(user);

            // Act: Try to validate with an incorrect password
            var result = await _userService.ValidateUser(userName, "wrongPassword"); // Incorrect password

            // Assert: Should return null because the password is incorrect
            Assert.IsNull(result);
        }

        [Test]
        public async Task ValidateUser_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var userName = "nonExistingUser";
            _userRepositoryMock.Setup(repo => repo.GetUserByUsernameAsync(userName))
                               .ReturnsAsync((User)null);

            // Act
            var result = await _userService.ValidateUser(userName, "password123");

            // Assert
            Assert.IsNull(result);
        }
    }
}
