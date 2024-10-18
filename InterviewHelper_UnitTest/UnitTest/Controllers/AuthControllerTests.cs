using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using intervirew_helper_backend.Controllers;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.services.IServices;
using InterviewHelper.Business.DTOs;
using Newtonsoft.Json.Linq;

namespace InterviewHelper.Tests
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
            _userServiceMock = new Mock<IUserService>();
            _configurationMock = new Mock<IConfiguration>();

            // Mock JWT key configuration
            _configurationMock.Setup(c => c["ApiSettings:Key"])
                              .Returns("SuperSecretKey123SuperSecretKey123SuperSecretKey123SuperSecretKey123SuperSecretKey123SuperSecretKey123SuperSecretKey123SuperSecretKey123");

            _authController = new AuthController(_userServiceMock.Object, _configurationMock.Object);
        }

        // ======================= Register Tests =========================

        [Test]
        public async Task Register_ValidUser_ReturnsSuccess()
        {
            // Arrange
            var userAuth = new UserAuth { UserName = "newUser", UserPassword = "password123" };
            _userServiceMock.Setup(s => s.IsUserExist(userAuth.UserName)).ReturnsAsync(false);
            _userServiceMock.Setup(s => s.AddUser(It.IsAny<User>())).Returns(Task.CompletedTask);

            // Act
            var result = await _authController.Register(userAuth) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("success", ((dynamic)result.Value)["status"]);
        }

        [Test]
        public async Task Register_UserAlreadyExists_ReturnsConflict()
        {
            // Arrange
            var userAuth = new UserAuth { UserName = "existingUser", UserPassword = "password123" };
            _userServiceMock.Setup(s => s.IsUserExist(userAuth.UserName)).ReturnsAsync(true);

            // Act
            var result = await _authController.Register(userAuth) as ConflictObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(409, result.StatusCode);
            Assert.AreEqual("error", ((dynamic)result.Value)["status"]);
            Assert.AreEqual("User already exists.", ((dynamic)result.Value)["message"]);
        }

        [Test]
        public async Task Register_InvalidUserData_ReturnsBadRequest()
        {
            // Arrange
            var userAuth = new UserAuth { UserName = "", UserPassword = "" };

            // Act
            var result = await _authController.Register(userAuth) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("error", ((dynamic)result.Value)["status"]);
            Assert.AreEqual("Invalid user data.", ((dynamic)result.Value)["message"]);
        }

        // ======================= Login Tests =========================

        [Test]
        public async Task Login_ValidCredentials_ReturnsSuccessWithToken()
        {    // Arrange
            var loginRequest = new UserAuth { UserName = "testuser", UserPassword = "password123" };
            var user = new User { UserId = 1, UserName = "testuser", IsActive = true };
            _userServiceMock.Setup(s => s.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _authController.Login(loginRequest);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>(), "Result should be OkObjectResult");
            var okResult = (OkObjectResult)result;

            Assert.That(okResult.Value, Is.Not.Null, "OkObjectResult.Value should not be null");

            var responseObj = JObject.FromObject(okResult.Value);
            Console.WriteLine($"Response: {responseObj}"); // Log the entire response

            Assert.That(responseObj["Message"].ToString(), Is.EqualTo("Login successful."), "Message should be 'Login successful.'");
            Assert.That(responseObj["Token"].ToString(), Is.Not.Empty, "Token should not be empty");

            var userObj = responseObj["User"];
            Assert.That(userObj["UserId"].Value<int>(), Is.EqualTo(1), "UserId should be 1");
            Assert.That(userObj["UserName"].ToString(), Is.EqualTo("testuser"), "UserName should be 'testuser'");
            Assert.That(userObj["IsActive"].Value<bool>(), Is.True, "IsActive should be true");
        
        /*            // Act
                    var result = await _authController.Login(loginRequest) as OkObjectResult;

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.AreEqual(200, result.StatusCode);
                    Assert.AreEqual("Login successful.", ((dynamic)result.Value).Message);
                    Assert.IsNotNull(((dynamic)result.Value).Token);
        */
    }

        [Test]
        public async Task Login_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginRequest = new UserAuth { UserName = "invalidUser", UserPassword = "wrongPassword" };
            _userServiceMock.Setup(s => s.ValidateUser(loginRequest.UserName, loginRequest.UserPassword))
                            .ReturnsAsync((User)null);

            // Act
            var result = await _authController.Login(loginRequest) as UnauthorizedObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(401, result.StatusCode);
            Assert.AreEqual("Invalid username or password.", result.Value);
        }

        [Test]
        public async Task Login_InactiveUser_ReturnsForbidden()
        {
            // Arrange
            var loginRequest = new UserAuth { UserName = "inactiveuser", UserPassword = "password123" };
            var inactiveUser = new User { UserId = 2, UserName = "inactiveuser", IsActive = false };
            _userServiceMock.Setup(s => s.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(inactiveUser);

            // Act
            var result = await _authController.Login(loginRequest);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>(), "Result should be ObjectResult");
            var objectResult = (ObjectResult)result;

            Assert.That(objectResult.StatusCode, Is.EqualTo(403), "Status code should be 403 (Forbidden)");

            Assert.That(objectResult.Value, Is.Not.Null, "ObjectResult.Value should not be null");

            var responseObj = JObject.FromObject(objectResult.Value);
            Console.WriteLine($"Response: {responseObj}"); // Log the entire response

            Assert.That(responseObj["Message"], Is.Not.Null, "Response should contain a 'Message' property");
            Assert.That(responseObj["Message"].ToString(), Is.EqualTo("Your account is not active."), "Message should be 'Your account is not active.'");

            // Ensure no other properties are present
            Assert.That(responseObj.Count, Is.EqualTo(1), "Response should only contain the Message property");
        }

 


    }
}
