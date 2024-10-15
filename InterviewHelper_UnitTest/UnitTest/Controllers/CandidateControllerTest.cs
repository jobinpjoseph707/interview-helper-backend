using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Controllers;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;


[TestFixture]
public class CandidateControllerTest
    {
    private Mock<ICandidateService> _candidateServiceMock;
    private CandidateController _controller;

    [SetUp]
    public void Setup()
    {
        _candidateServiceMock = new Mock<ICandidateService>();
        _controller = new CandidateController(_candidateServiceMock.Object);
    }

    [Test]
    public async Task PostCandidate_ReturnsCreatedCandidate()
    {
        // Arrange
        var candidateDto = new CandidateDto { Name = "John Doe", ApplicationRoleId = 1 };
        var createdCandidate = new Candidate { CandidateId = 1, Name = "John Doe", ApplicationRoleId = 1 };

        _candidateServiceMock.Setup(service => service.CreateCandidateAsync(candidateDto))
                             .ReturnsAsync(createdCandidate);

        // Act
        var result = await _controller.PostCandidate(candidateDto);

        // Assert
        var createdAtActionResult = result.Result as CreatedAtActionResult;
        Assert.IsNotNull(createdAtActionResult);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(201));
        Assert.That(createdAtActionResult.ActionName, Is.EqualTo("GetCandidateById"));

        var returnedCandidate = createdAtActionResult.Value as Candidate;
        Assert.IsNotNull(returnedCandidate);
        Assert.That(returnedCandidate.CandidateId, Is.EqualTo(1));
        Assert.That(returnedCandidate.Name, Is.EqualTo("John Doe"));
    }

    // Failure Path: Exception occurs when creating a candidate
    [Test]
    public async Task PostCandidate_ReturnsBadRequest_OnFailure()
    {
        // Arrange
        var candidateDto = new CandidateDto { Name = "Jane Doe", ApplicationRoleId = 7 };
        _candidateServiceMock.Setup(service => service.CreateCandidateAsync(candidateDto))
                             .ThrowsAsync(new Exception("Invalid ApplicationRoleId."));

        // Act
        var actionResult = await _controller.PostCandidate(candidateDto);

        // Assert
        var result = actionResult.Result as BadRequestObjectResult;
        Assert.IsNotNull(result); // Ensure we get a BadRequest result
        Assert.That(result.StatusCode, Is.EqualTo(400));

        var responseObj = result.Value as IDictionary<string, object>;
        Assert.IsNotNull(responseObj); // Ensure the object is not null
        Assert.That(responseObj["message"], Is.EqualTo("Invalid ApplicationRoleId."));
    }

    // Happy Path: Candidate found
    [Test]
    public async Task GetCandidateById_ReturnsCandidate()
    {
        // Arrange
        var candidate = new Candidate { CandidateId = 1, Name = "John Doe" };

        _candidateServiceMock.Setup(service => service.GetCandidateByIdAsync(1))
                             .ReturnsAsync(candidate);

        // Act
        var actionResult = await _controller.GetCandidateById(1);

        // Assert
        var okResult = actionResult.Result as OkObjectResult;
        Assert.IsNotNull(okResult);  // Ensure that the result is an OkObjectResult
        Assert.That(okResult.StatusCode, Is.EqualTo(200));  // Ensure the status code is 200 (OK)

        var returnedCandidate = okResult.Value as Candidate;  // Cast the Value to Candidate
        Assert.IsNotNull(returnedCandidate);  // Ensure the returned candidate is not null
        Assert.That(returnedCandidate.CandidateId, Is.EqualTo(1));  // Ensure the CandidateId is 1
        Assert.That(returnedCandidate.Name, Is.EqualTo("John Doe"));  // Ensure the Name is "John Doe"
    }

    // Failure Path: Candidate not found
    [Test]
    public async Task GetCandidateById_ReturnsNotFound_WhenCandidateNotExists()
    {
        // Arrange
        _candidateServiceMock.Setup(service => service.GetCandidateByIdAsync(1))
                             .ReturnsAsync(null as Candidate);

        // Act
        var result = await _controller.GetCandidateById(1);

        // Assert
        var notFoundResult = result.Result as NotFoundResult;
        Assert.IsNotNull(notFoundResult);
        Assert.That(notFoundResult.StatusCode, Is.EqualTo(404));
    }


    // Happy Path: Filtered candidates found
    [Test]
    public async Task GetFilteredCandidates_ReturnsCandidates()
    {
        // Arrange
        var mockCandidates = new List<CandidateDto>
    {
        new CandidateDto { Id = 1, Name = "John Doe", ApplicationRoleId = 1 },
        new CandidateDto { Id = 2, Name = "Jane Doe", ApplicationRoleId = 2 }
    };

        _candidateServiceMock.Setup(service => service.GetFilteredCandidatesAsync(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>()))
                             .ReturnsAsync(mockCandidates);

        // Act
        var result = await _controller.GetFilteredCandidates("Doe", null, null, null);

        // Assert
        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.That(okResult.StatusCode, Is.EqualTo(200));

        var returnedCandidates = okResult.Value as IEnumerable<CandidateDto>;
        Assert.IsNotNull(returnedCandidates);
        Assert.That(returnedCandidates.Count(), Is.EqualTo(2));
    }


    // Failure Path: Exception during filtering
    [Test]
    public async Task GetFilteredCandidates_ReturnsBadRequest_OnFailure()
    {
        // Arrange
        string name = "Doe";
        int? roleId = null;
        DateTime? fromDate = null;
        DateTime? toDate = null;

        _candidateServiceMock.Setup(service => service.GetFilteredCandidatesAsync(name, roleId, fromDate, toDate))
                             .ThrowsAsync(new Exception("Error fetching candidates"));

        // Act
        var result = await _controller.GetFilteredCandidates(name, roleId, fromDate, toDate);

        // Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;

        Assert.IsNotNull(badRequestResult); // Ensure we get a BadRequest result
        Assert.That(badRequestResult.StatusCode, Is.EqualTo(400));

        var responseObj = badRequestResult.Value as IDictionary<string, object>;
        Assert.IsNotNull(responseObj); // Ensure the object is not null
        Assert.That(responseObj["message"], Is.EqualTo("Error fetching candidates"));
    }

}





