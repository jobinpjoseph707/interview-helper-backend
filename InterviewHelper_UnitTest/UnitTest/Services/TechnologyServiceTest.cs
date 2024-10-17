using InterviewHelper.Business.services;
using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;


[TestFixture]
public class TechnologyServiceTest
    {
    private Mock<ITechnologyRepository> _technologyRepositoryMock;
    private TechnologyService _technologyService;

    [SetUp]
    public void Setup() { 
    
    _technologyRepositoryMock = new Mock<ITechnologyRepository>();
    _technologyService=new TechnologyService( _technologyRepositoryMock.Object );

    }

    // Happy Test
    [Test]
    public async Task GetAllTechnologiesAsync_ShouldReturnTechnologies_WhenTechnologiesExist()
    {

        //Arrange
       var expectedTechnologies=new List<Technology>
       {
           new Technology
           {
               TechnologyId = 1,
               Name="Angular"
           },
           new Technology
           {
               TechnologyId= 2,
               Name="React"
           }
        };

        _technologyRepositoryMock.Setup(repo => repo.GetAllTechnologiesAsync()).ReturnsAsync(expectedTechnologies);

        //Act
        var result=await _technologyService.GetAllTechnologiesAsync();

        //Assert
        Assert.That(result.Count,Is.EqualTo(expectedTechnologies.Count));
        Assert.That(result,Is.EqualTo(expectedTechnologies));

    }

    //Failure Test
    [Test]
    public async Task GetAllTechnologiesAsync_ReturnsEmptyList_WhenNoActiveTechnologies()
    {
        //Arrange
        _technologyRepositoryMock.Setup(repo => repo.GetAllTechnologiesAsync()).ReturnsAsync(new List<Technology>());

        //Act
        var result = await _technologyService.GetAllTechnologiesAsync();

        //Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }
    }

