using NUnit.Framework;
using Moq;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewHelper.Business.DTOs;
using intervirew_helper_backend.Models;
using intervirew_helper_backend.Repository.IRepository;
using intervirew_helper_backend.services;

[TestFixture]
public class CandidateServiceTest
{
    private Mock<ICandidateRepository> _candidateRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private CandidateService _candidateService;

    [SetUp]
    public void Setup()
    {
        _candidateRepositoryMock = new Mock<ICandidateRepository>();
        _mapperMock = new Mock<IMapper>();
        _candidateService = new CandidateService(_candidateRepositoryMock.Object, _mapperMock.Object);
    }

    // Happy Path Test for CreateCandidateAsync
    [Test]
    public async Task CreateCandidateAsync_ValidCandidateDto_CreatesCandidateSuccessfully()
    {
        // Arrange
        var candidateDto = new CandidateDto
        {
            Name = "John Doe",
            ApplicationRoleId = 1,
            Technologies = new List<CandidateTechnologyScoreDto>
            {
                new CandidateTechnologyScoreDto { TechnologyId = 1, ExperienceLevelId = 2, Score = 90 },
                new CandidateTechnologyScoreDto { TechnologyId = 2, ExperienceLevelId = 3, Score = 85 }
            }
        };

        _candidateRepositoryMock.Setup(repo => repo.GetAllApplicationRolesAsync())
                                .ReturnsAsync(new List<ApplicationRole>
                                {
                                    new ApplicationRole { ApplicationRoleId = 1, Name = "Front End Developer" }
                                });

        var candidate = new Candidate();
        _mapperMock.Setup(mapper => mapper.Map<Candidate>(candidateDto)).Returns(candidate);

        _candidateRepositoryMock.Setup(repo => repo.AddCandidateAsync(candidate)).ReturnsAsync(candidate);

        // Act
        var result = await _candidateService.CreateCandidateAsync(candidateDto);

        // Assert
        Assert.IsNotNull(result);
        _candidateRepositoryMock.Verify(repo => repo.AddCandidateAsync(It.IsAny<Candidate>()), Times.Once);
    }

    // Failure Test for CreateCandidateAsync with invalid ApplicationRoleId
    [Test]
    public void CreateCandidateAsync_InvalidApplicationRoleId_ThrowsException()
    {
        // Arrange
        var candidateDto = new CandidateDto { ApplicationRoleId = 999 };

        _candidateRepositoryMock.Setup(repo => repo.GetAllApplicationRolesAsync())
                                .ReturnsAsync(new List<ApplicationRole>
                                {
                                    new ApplicationRole { ApplicationRoleId = 1, Name = "Front EndDeveloper" }
                                });

        // Act & Assert
        var ex = Assert.ThrowsAsync<Exception>(() => _candidateService.CreateCandidateAsync(candidateDto));
        Assert.That(ex.Message, Is.EqualTo("Invalid ApplicationRoleId."));
    }


    // Happy Path Test for GetCandidateByIdAsync
    [Test]
    public async Task GetCandidateByIdAsync_ValidId_ReturnsCandidate()
    {
        // Arrange
        var candidate = new Candidate { CandidateId = 1, Name = "John Doe" };

        _candidateRepositoryMock.Setup(repo => repo.GetCandidateByIdAsync(1))
                                .ReturnsAsync(candidate);

        // Act
        var result = await _candidateService.GetCandidateByIdAsync(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.CandidateId, Is.EqualTo(1));
    }

    // Failure Test for GetCandidateByIdAsync with invalid ID
    [Test]
    public async Task GetCandidateByIdAsync_InvalidId_ReturnsNull()
    {
        // Arrange
        _candidateRepositoryMock.Setup(repo => repo.GetCandidateByIdAsync(It.IsAny<int>()))
                                .ReturnsAsync((Candidate)null);

        // Act
        var result = await _candidateService.GetCandidateByIdAsync(999);

        // Assert
        Assert.IsNull(result);
    }

    // Happy Path Test for GetAllTechnologiesAsync
    [Test]
    public async Task GetAllTechnologiesAsync_ReturnsTechnologies()
    {
        // Arrange
        var technologies = new List<Technology>
        {
            new Technology { TechnologyId = 1, Name = "C#" },
            new Technology { TechnologyId = 2, Name = "JavaScript" }
        };

        _candidateRepositoryMock.Setup(repo => repo.GetAllTechnologiesAsync())
                                .ReturnsAsync(technologies);

        // Act
        var result = await _candidateService.GetAllTechnologiesAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Count(), Is.EqualTo(2));
    }

    //Failure Path
    [Test]
    public async Task GetAllTechnologiesAsync_NoTechnologies_ReturnsEmptyList()
    {
        // Arrange
        // Setup the mock repository to return an empty list
        _candidateRepositoryMock.Setup(repo => repo.GetAllTechnologiesAsync())
                                .ReturnsAsync(new List<Technology>());

        // Act
        var result = await _candidateService.GetAllTechnologiesAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);

        // Verify that the repository method was called exactly once
        _candidateRepositoryMock.Verify(repo => repo.GetAllTechnologiesAsync(), Times.Once);
    }



    // Happy Path Test for GetAllExperienceLevels
    [Test]
    public async Task GetAllExperienceLevelsAsync_ReturnsLevels()
    {
        // Arrange
        var experienceLevels = new List<ExperienceLevel>
        {
            new ExperienceLevel { ExperienceLevelId = 1, Level = "Fresher" },
            new ExperienceLevel { ExperienceLevelId = 2, Level = "Mid" }
        };

        _candidateRepositoryMock.Setup(repo => repo.GetAllExperienceLevelsAsync())
                                .ReturnsAsync(experienceLevels);

        // Act
        var result = await _candidateService.GetAllExperienceLevelsAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Count(), Is.EqualTo(2));
    }

    //Failure Path
    [Test]
    public async Task GetAllExperienceLevelsAsync_NoExperienceLevels_ReturnsEmptyList()
    {
        // Arrange
        // Setup the mock repository to return an empty list
        _candidateRepositoryMock.Setup(repo => repo.GetAllExperienceLevelsAsync())
                                .ReturnsAsync(new List<ExperienceLevel>());

        // Act
        var result = await _candidateService.GetAllExperienceLevelsAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);

        // Verify that the repository method was called exactly once
        _candidateRepositoryMock.Verify(repo => repo.GetAllExperienceLevelsAsync(), Times.Once);
    }


    // Happy Path Test for GetAllApplicationRoles
    [Test]
    public async Task GetAllApplicationRolesAsync_ReturnsApplicationRoles()
    {
        // Arrange
        var applicationRoles = new List<ApplicationRole>
        {
            new ApplicationRole { ApplicationRoleId = 1, Name = "Front End Developer" },
            new ApplicationRole { ApplicationRoleId = 2, Name = "Back End Developer" }
        };

        _candidateRepositoryMock.Setup(repo => repo.GetAllApplicationRolesAsync())
                                .ReturnsAsync(applicationRoles);

        // Act
        var result = await _candidateService.GetAllApplicationRolesAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.Count(), Is.EqualTo(2));
    }

    //Failure Path
    [Test]
    public async Task GetAllApplicationRolesAsync_NoApplicationRoles_ReturnsEmptyList()
    {
        // Arrange
        // Setup the mock repository to return an empty list
        _candidateRepositoryMock.Setup(repo => repo.GetAllApplicationRolesAsync())
                                .ReturnsAsync(new List<ApplicationRole>());

        // Act
        var result = await _candidateService.GetAllApplicationRolesAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);

        // Verify that the repository method was called exactly once
        _candidateRepositoryMock.Verify(repo => repo.GetAllApplicationRolesAsync(), Times.Once);
    }


}
