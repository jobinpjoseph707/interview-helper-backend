using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using intervirew_helper_backend.Controllers;
using intervirew_helper_backend.services.IServices;
using intervirew_helper_backend.Models;
using InterviewHelper.Business.DTOs;
using System.Collections.Generic;

namespace intervirew_helper_backend.Tests
{
    [TestFixture]
    public class AuthControllerTests
    {
        private Mock<IUserService> _userServiceMock;
        private Mock<IConfiguration> _configurationMock;
        private AuthController _authController;

        [SetUp]
        public void Setup()
        {
            // Initialize the mocks
            _userServiceMock = new Mock<IUserService>();
            _configurationMock = new Mock<IConfiguration>();

            // Setup configuration mock for JWT key
            _configurationMock.Setup(config => config["ApiSettings:Key"])
                .Returns("your-secure-secret-key");

            // Initialize the AuthController with the mocked services
            _authController = new AuthController(_userServiceMock.Object, _configurationMock.Object);
        }

        // ------------ Register Tests ------------

        [Test]
        public async Task Register_User_Success()
        {
            // Arrange
            var newUser = new UserAuth { UserName = "testuser", UserPassword = "testpass" };

            // Mock the service to return false, meaning the user doesn't exist
            _userServiceMock.Setup(s => s.IsUserExist(newUser.UserName))
                .ReturnsAsync(false);

            // Mock adding a new user
            _userServiceMock.Setup(s => s.AddUser(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _authController.Register(newUser);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var response = okResult.Value as Dictionary<string, string>;
            Assert.AreEqual("success", response["status"]);
            Assert.AreEqual("User registered successfully.", response["message"]);
        }

        [Test]
        public async Task Register_User_Failure_UserAlreadyExists()
        {
            // Arrange
            var newUser = new UserAuth { UserName = "testuser", UserPassword = "testpass" };

            // Mock the service to return true, meaning the user already exists
            _userServiceMock.Setup(s => s.IsUserExist(newUser.UserName))
                .ReturnsAsync(true);

            // Act
            var result = await _authController.Register(newUser);

            // Assert
            Assert.IsInstanceOf<ConflictObjectResult>(result);
            var conflictResult = result as ConflictObjectResult;
            var response = conflictResult.Value as Dictionary<string, string>;
            Assert.AreEqual("error", response["status"]);
            Assert.AreEqual("User already exists.", response["message"]);
        }

        // ------------ Login Tests ------------

        [Test]
        public async Task Login_User_Success()
        {
            // Arrange
            var userAuth = new UserAuth { UserName = "testuser", UserPassword = "testpass" };
            var user = new User { UserId = 1, UserName = "testuser", UserPassword = "testpass", IsActive = true };

            // Mock service to return a valid user
            _userServiceMock.Setup(s => s.ValidateUser(userAuth.UserName, userAuth.UserPassword))
                .ReturnsAsync(user);

            // Act
            var result = await _authController.Login(userAuth);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var response = okResult.Value as Dictionary<string, object>;
            Assert.AreEqual("Login successful.", response["Message"]);
            Assert.IsNotNull(response["Token"]);
        }

        [Test]
        public async Task Login_User_Failure_InvalidCredentials()
        {
            // Arrange
            var userAuth = new UserAuth { UserName = "wronguser", UserPassword = "wrongpass" };

            // Mock service to return null for invalid credentials
            _userServiceMock.Setup(s => s.ValidateUser(userAuth.UserName, userAuth.UserPassword))
                .ReturnsAsync((User)null);

            // Act
            var result = await _authController.Login(userAuth);

            // Assert
            Assert.IsInstanceOf<UnauthorizedObjectResult>(result);
            var unauthorizedResult = result as UnauthorizedObjectResult;
            Assert.AreEqual("Invalid username or password.", unauthorizedResult.Value);
        }

        [Test]
        public async Task Login_User_Failure_InactiveUser()
        {
            // Arrange
            var userAuth = new UserAuth { UserName = "testuser", UserPassword = "testpass@5001" };
            var inactiveUser = new User { UserId = 1, UserName = "testuser", UserPassword = "testpass@500", IsActive = false };

            // Mock service to return an inactive user
            _userServiceMock.Setup(s => s.ValidateUser(userAuth.UserName, userAuth.UserPassword))
                .ReturnsAsync(inactiveUser);

            // Act
            var result = await _authController.Login(userAuth);

            // Assert
            Assert.IsInstanceOf<ObjectResult>(result);
            var forbiddenResult = result as ObjectResult;
            Assert.AreEqual(403, forbiddenResult.StatusCode);
            var response = forbiddenResult.Value as Dictionary<string, object>;
            Assert.AreEqual("Your account is not active.", response["Message"]);
            Assert.IsFalse((bool)response["IsActive"]);
        }
    }
}
