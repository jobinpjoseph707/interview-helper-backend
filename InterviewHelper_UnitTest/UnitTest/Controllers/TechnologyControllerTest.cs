using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Controllers;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

[TestFixture]
    public class TechnologyControllerTest
    {
    private Mock<ITechnologyService> _technologyServiceMock;
    private TechnologyController _controller;

    [SetUp]
    public void Setup()
    {
        _technologyServiceMock = new Mock<ITechnologyService>();
        _controller = new TechnologyController(_technologyServiceMock.Object);
    }

    [Test]
    public async Task GetAllTechnologies_ReturnsOkWithTechnologies()
    {
        // Arrange
        var mockTechnologies = new List<Technology>
        {
            new Technology { TechnologyId = 1, Name = "Angular", IsActive = true },
            new Technology { TechnologyId = 3, Name = "Vue.js", IsActive = true }
        };

        _technologyServiceMock.Setup(service => service.GetAllTechnologiesAsync())
                                   .ReturnsAsync(mockTechnologies);

        // Act
        var result = await _controller.GetAllTechnologies();

        // Assert
        var okResult = result.Result as OkObjectResult;

        Assert.IsNotNull(okResult);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));

        var returnedTechnologies = okResult.Value as IEnumerable<Technology>;
        Assert.IsNotNull(returnedTechnologies);
        Assert.That(returnedTechnologies.Count(), Is.EqualTo(2)); 
    }

    [Test]
    public async Task GetAllTechnologies_ReturnsNotFound_WhenNoActiveTechnologies()
    {
        // Arrange
        _technologyServiceMock.Setup(service => service.GetAllTechnologiesAsync())
                                   .ReturnsAsync(new List<Technology>()); 

        // Act
        ActionResult<IEnumerable<Technology>> result = await _controller.GetAllTechnologies();

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result); // Check if result is NotFound
    }

}

