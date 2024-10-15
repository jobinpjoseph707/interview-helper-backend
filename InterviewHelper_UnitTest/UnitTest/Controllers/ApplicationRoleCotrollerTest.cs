using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Controllers;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

[TestFixture]
public class ApplicationRoleControllerTest
{
    private Mock<IApplicationRoleService> _applicationRoleServiceMock;
    private ApplicationRoleController _controller;

    [SetUp]
    public void Setup()
    {
        _applicationRoleServiceMock = new Mock<IApplicationRoleService>();
        _controller = new ApplicationRoleController(_applicationRoleServiceMock.Object);
    }

    [Test]
    public async Task GetAllApplicationRoles_ReturnsOkWithRoles()
    {
        // Arrange
        var mockRoles = new List<ApplicationRole>
        {
            new ApplicationRole { ApplicationRoleId = 1, Name = "Front End Developer", IsActive = true },
            new ApplicationRole { ApplicationRoleId = 3, Name = "Database SQL", IsActive = true }
        };

        _applicationRoleServiceMock.Setup(service => service.GetAllApplicationRolesAsync())
                                   .ReturnsAsync(mockRoles);

        // Act
        var result = await _controller.GetAllApplicationRoles();

        // Assert
        var okResult = result.Result as OkObjectResult;

        Assert.IsNotNull(okResult);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));

        var returnedRoles = okResult.Value as IEnumerable<ApplicationRole>;
        Assert.IsNotNull(returnedRoles);
        Assert.That(returnedRoles.Count(), Is.EqualTo(2)); // Expects two active roles
    }

    [Test]
    public async Task GetAllApplicationRoles_ReturnsNotFound_WhenNoActiveRoles()
    {
        // Arrange
        _applicationRoleServiceMock.Setup(service => service.GetAllApplicationRolesAsync())
                                   .ReturnsAsync(new List<ApplicationRole>()); // Simulate no roles

        // Act
        ActionResult<IEnumerable<ApplicationRole>> result = await _controller.GetAllApplicationRoles();

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }

}
