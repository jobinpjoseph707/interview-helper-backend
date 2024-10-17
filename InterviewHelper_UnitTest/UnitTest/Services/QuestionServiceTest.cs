using InterviewHelper.Business.DTOs;
using InterviewHelper.Business.services;
using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

[TestFixture]
public class QuestionServiceTest
    {
    private Mock<IQuestionRepository> _questionRepositoryMock;
    private QuestionService _questionService;

    [SetUp]
    public void Setup() { 
    
        _questionRepositoryMock = new Mock<IQuestionRepository>();
        _questionService = new QuestionService(_questionRepositoryMock.Object);

    }

    // Happy Path Test for GetQuestions
    [Test]
    public async Task GetQuestions_ValidRequest_ReturnsGroupedQuestions()
    {
        // Arrange
        var request = new QuestionRequest
        {
            Technologies = new List<TechnologyExperience>
            {
                new TechnologyExperience { TechnologyId = 1, ExperienceLevelId = 2 }
            }
        };

        var questions = new List<Question>
        {
            new Question { QuestionId = 1, Text = "Sample Question", TechnologyId = 1, ExperienceLevelId = 2, Technology = new Technology { Name = "Angular" } }
        };

        _questionRepositoryMock.Setup(repo => repo.GetQuestionsByTechnologiesAndExperienceLevels(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                               .ReturnsAsync(questions);

        // Act
        var result = await _questionService.GetQuestions(request);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Count, Is.EqualTo(1));  // Ensure there's 1 grouped response
        Assert.That(result[0].Name, Is.EqualTo("Angular"));
        Assert.That(result[0].Questions.Count, Is.EqualTo(1));  // Ensure the correct question is returned
    }

    // Failure Test for GetQuestions with null request
    [Test]
    public async Task GetQuestions_NullRequest_ReturnsNull()
    {
        // Arrange
        QuestionRequest request = null;

        // Act
        var result = await _questionService.GetQuestions(request);

        // Assert
        Assert.IsNull(result);
    }
    // Happy Path Test for UpdateCandidateScoreAndReview
    [Test]
    public async Task UpdateCandidateScoreAndReview_ValidInputs_UpdatesSuccessfully()
    {
        // Arrange
        int candidateId = 1;
        decimal overallScore = 85.5m;
        string review = "Good performance";

        // Act
        await _questionService.UpdateCandidateScoreAndReview(candidateId, overallScore, review);

        // Assert
        _questionRepositoryMock.Verify(repo => repo.UpdateCandidateScoreAndReview(candidateId, overallScore, review), Times.Once);
    }

    // Failure Test for UpdateCandidateScoreAndReview with invalid candidateId
    [Test]
    public void UpdateCandidateScoreAndReview_InvalidCandidateId_ThrowsException()
    {
        // Arrange
        int candidateId = -1;
        decimal overallScore = 85.5m;
        string review = "Good performance";

        _questionRepositoryMock.Setup(repo => repo.UpdateCandidateScoreAndReview(candidateId, overallScore, review))
                               .Throws(new Exception("Invalid candidate ID"));

        // Act & Assert
        Assert.ThrowsAsync<Exception>(() => _questionService.UpdateCandidateScoreAndReview(candidateId, overallScore, review));
    }

    // Happy Path Test for UpdateCandidateTechnologyScore
    [Test]
    public async Task UpdateCandidateTechnologyScore_ValidInputs_UpdatesSuccessfully()
    {
        // Arrange
        int candidateId = 1;
        var technologyScores = new Dictionary<int, decimal>
    {
        { 1, 75.5m },  // TechnologyId 1 with score 75.5
        { 2, 85.0m }   // TechnologyId 2 with score 85.0
    };

        // Act
        await _questionService.UpdateCandidateTechnologyScore(candidateId, technologyScores);

        // Assert
        // Verify that the UpdateCandidateTechnologyScore method is called for each entry in the dictionary
        foreach (var entry in technologyScores)
        {
            _questionRepositoryMock.Verify(repo => repo.UpdateCandidateTechnologyScore(candidateId, entry.Key, entry.Value), Times.Once);
        }
    }
    // Failure Test for UpdateCandidateTechnologyScore with invalid candidateId
    [Test]
    public void UpdateCandidateTechnologyScore_InvalidCandidateId_ThrowsException()
    {
        // Arrange
        int candidateId = -1;  // Invalid candidate ID
        var technologyScores = new Dictionary<int, decimal>
    {
        { 1, 75.5m },
        { 2, 85.0m }
    };

        _questionRepositoryMock.Setup(repo => repo.UpdateCandidateTechnologyScore(candidateId, It.IsAny<int>(), It.IsAny<decimal>()))
                               .Throws(new Exception("Invalid candidate ID"));

        // Act & Assert
        Assert.ThrowsAsync<Exception>(() => _questionService.UpdateCandidateTechnologyScore(candidateId, technologyScores));
    }


}

