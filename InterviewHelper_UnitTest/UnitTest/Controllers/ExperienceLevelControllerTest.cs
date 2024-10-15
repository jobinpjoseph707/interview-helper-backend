using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Controllers;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

[TestFixture]
    public class ExperienceLevelControllerTest
    {
    private Mock<IExperienceLevelService> _experienceLevelServiceMock;
    private ExperienceLevelController _controller;

    [SetUp]
    public void Setup()
    {
        _experienceLevelServiceMock = new Mock<IExperienceLevelService>();
        _controller = new ExperienceLevelController(_experienceLevelServiceMock.Object);
    }

    [Test]
    public async Task GetAllExperienceLevels_ReturnsOkWithLevels()
    {
        // Arrange
        var mockLevels = new List<ExperienceLevel>
        {
            new ExperienceLevel { ExperienceLevelId = 1, Level = "Fresher", IsActive = true },
            new ExperienceLevel { ExperienceLevelId = 3, Level = "Senior", IsActive = true }
        };

        _experienceLevelServiceMock.Setup(service => service.GetAllExperienceLevelsAsync())
                                   .ReturnsAsync(mockLevels);

        // Act
        var result = await _controller.GetAllExperienceLevels();

        // Assert
        var okResult = result.Result as OkObjectResult;

        Assert.IsNotNull(okResult);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));

        var returnedLevels = okResult.Value as IEnumerable<ExperienceLevel>;
        Assert.IsNotNull(returnedLevels);
        Assert.That(returnedLevels.Count(), Is.EqualTo(2)); 
    }

    [Test]
    public async Task GetAllExperienceLevels_ReturnsNotFound_WhenNoActiveLevels()
    {
        // Arrange
        _experienceLevelServiceMock.Setup(service => service.GetAllExperienceLevelsAsync())
                                   .ReturnsAsync(new List<ExperienceLevel>()); // Simulate no active levels

        // Act
        ActionResult<IEnumerable<ExperienceLevel>> result = await _controller.GetAllExperienceLevels();

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result); // Check if result is NotFound
    }


}

