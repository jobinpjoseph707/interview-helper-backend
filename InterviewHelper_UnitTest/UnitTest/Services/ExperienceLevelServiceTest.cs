using InterviewHelper.Business.services;
using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;


[TestFixture]
public class ExperienceLevelServiceTest
{

    private Mock<IExperienceLevelRepository> _experienceLevelRepositoryMock;
    private ExperienceLevelService _experienceLevelService;

    [SetUp]
    public void Setup()
    {
        _experienceLevelRepositoryMock = new Mock<IExperienceLevelRepository>();
        _experienceLevelService = new ExperienceLevelService(_experienceLevelRepositoryMock.Object);
    }

    //Happy Path Test
    [Test]
    public async Task GetAllExperienceLevelsAsync_ShouldReturnLevels_WhenLevelsExist()
    {
        //Arrange
        var expectedLevel = new List<ExperienceLevel>
        {
            new ExperienceLevel{
            ExperienceLevelId = 1,
            Level = "Mid"
            },
            new ExperienceLevel
            {
                ExperienceLevelId=2,
                Level="Senior"
            }
        };

        _experienceLevelRepositoryMock.Setup(repo=>repo.GetAllExperienceLevelsAsync().Result).Returns(expectedLevel);

        //Act
        var result= await _experienceLevelService.GetAllExperienceLevelsAsync();

        //Assert
        Assert.That(result, Is.EqualTo(expectedLevel));
        Assert.That(result.Count, Is.EqualTo(expectedLevel.Count));

    }



//Failure Test
[Test]
public async Task GetAllApplicationLevelsAsync_ReturnsEmptyList_WhenNoActiveLevels()
{
        //Arrange
        _experienceLevelRepositoryMock.Setup(repo => repo.GetAllExperienceLevelsAsync()).ReturnsAsync(new List<ExperienceLevel>());

        //Act
        var result = await _experienceLevelService.GetAllExperienceLevelsAsync();

        //Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);

    }
}
