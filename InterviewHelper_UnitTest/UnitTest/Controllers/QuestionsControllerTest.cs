using Azure.Core;
using InterviewHelper.Business.DTOs;
using InterviewHelper.Business.services.IServices;
using intervirew_helper_backend.Controllers;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;


[TestFixture]

public class QuestionsControllerTest
{
    private Mock<IQuestionService> _questionServiceMock;
    private QuestionsController _controller;

    [SetUp]
    public void Setup()
    {
        _questionServiceMock = new Mock<IQuestionService>();
        _controller = new QuestionsController(_questionServiceMock.Object);
    }
    //Happy Test for  [HttpPost("get-questions")]
    [Test]
    public async Task GetQuestions_ReturnsOkResult_WhenServiceReturnsData()
    {
        // Arrange
        var request = new QuestionRequest
        {
            Technologies = new List<TechnologyExperience>
        {
            new TechnologyExperience { TechnologyId = 1, ExperienceLevelId=1 },
            new TechnologyExperience { TechnologyId = 2,ExperienceLevelId=2 },
            new TechnologyExperience { TechnologyId = 3, ExperienceLevelId=3 }
        },
            CandidateId = 1,
        };

        var expectedResult = new List<RoleResultResponse>
    {
        new RoleResultResponse
        {
            TechnologyId = 2,
            Name = "Angular",
            Questions = new List<QuestionResponse>
            {
                new QuestionResponse
                {
                    Id = 1,
                    Text = "How does Change Detection work in Angular?",
                    Role = "Angular",
                    Answer = "null"
                },
                new QuestionResponse
                {
                    Id = 2,
                    Text = "Explain Angular Pipes.",
                    Role = "Angular",
                    Answer = "null"
                },
                new QuestionResponse
                {
                    Id = 3,
                    Text = "What are Angular Services?",
                    Role = "Angular",
                    Answer = "null"
                }

            }
        }
    };

        _questionServiceMock.Setup(service => service.GetQuestions(request))
                            .ReturnsAsync(expectedResult);

        // Act
        var actionResult = await _controller.GetQuestions(request);

        // Assert
        Assert.That(actionResult.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = actionResult.Result as OkObjectResult;
        Assert.That(okResult.StatusCode, Is.EqualTo(200));

        var returnedResult = okResult.Value as IEnumerable<RoleResultResponse>;
        Assert.That(returnedResult, Is.Not.Null);
        Assert.That(returnedResult, Is.EqualTo(expectedResult));

        // Additional assertions to verify the content
        var firstRole = returnedResult.First();
        Assert.That(firstRole.TechnologyId, Is.EqualTo(2));
        Assert.That(firstRole.Name, Is.EqualTo("Angular"));
        Assert.That(firstRole.Questions.Count(), Is.EqualTo(3));
        Assert.That(firstRole.Questions.Select(q => q.Text).Distinct().Count(), Is.EqualTo(3));
    }



    //Failure Test for  [HttpPost("get-questions")]
    [Test]
    public async Task GetQuestions_ReturnsBadRequest_WhenRequestIsInvalidOrNoQuestionsFound()
    {
        // Arrange: Test for invalid request (empty technologies)
        var emptyRequest = new QuestionRequest
        {
            Technologies = new List<TechnologyExperience>(),  // Empty list to trigger invalid request
            CandidateId = 1,
        };

        // Act for invalid request
        var emptyRequestResult = await _controller.GetQuestions(emptyRequest);

        // Assert for invalid request
        Assert.That(emptyRequestResult.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResultEmpty = emptyRequestResult.Result as BadRequestObjectResult;
        Assert.That(badRequestResultEmpty.StatusCode, Is.EqualTo(400));
        Assert.That(badRequestResultEmpty.Value, Is.EqualTo("Invalid request or no technologies provided."));

        // Arrange: Test for no questions found
        var validRequest = new QuestionRequest
        {
            Technologies = new List<TechnologyExperience> { new TechnologyExperience() }, // Valid technology
            CandidateId = 1,
        };

        _questionServiceMock.Setup(service => service.GetQuestions(validRequest))
                            .ReturnsAsync((List<RoleResultResponse>)null);

        // Act for no questions found
        var noQuestionsResult = await _controller.GetQuestions(validRequest);

        // Assert for no questions found
        Assert.That(noQuestionsResult.Result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResultNoQuestions = noQuestionsResult.Result as BadRequestObjectResult;
        Assert.That(badRequestResultNoQuestions.StatusCode, Is.EqualTo(400));
        Assert.That(badRequestResultNoQuestions.Value, Is.EqualTo("No questions found."));
    }


    //Happy Test for   [HttpPost("update-candidate-score")]
    [Test]
    public async Task UpdateCandidateScore_ReturnsOkResult_WhenScoreUpdated()
    {
        // Arrange
        var validRequest = new UpdateCandidateScoreRequest
        {
            CandidateId = 1,
            OverallScore = 100.00m,
            Review = "Good"
        };

        _questionServiceMock.Setup(service => service.UpdateCandidateScoreAndReview(
            validRequest.CandidateId, validRequest.OverallScore, validRequest.Review))
            .Returns(Task.CompletedTask);

        // Act
        var actionResult = await _controller.UpdateCandidateScore(validRequest);

        // Assert
        Assert.That(actionResult, Is.InstanceOf<OkObjectResult>()); // Expecting OkObjectResult
        var okResult = actionResult as OkObjectResult;

        // Assert that the status code is 200
        Assert.That(okResult.StatusCode, Is.EqualTo(200));

        // Cast okResult.Value to IDictionary to access the 'message' property
        var response = okResult.Value as IDictionary<string, object>;

        Assert.That(response["message"], Is.EqualTo("Score updated successfully."));
    }


}

