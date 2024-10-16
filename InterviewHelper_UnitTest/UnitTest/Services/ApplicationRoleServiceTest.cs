using InterviewHelper.Business.services;
using InterviewHelper.DataAccess.Repository.IRepository;
using intervirew_helper_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;


[TestFixture]
public class ApplicationRoleServiceTest
{
    private Mock<IApplicationRoleRepository> _applicationRoleRepositoryMock;
    private ApplicationRoleService _applicationRoleService;

    [SetUp]
    public void Setup()
    {
        _applicationRoleRepositoryMock = new Mock<IApplicationRoleRepository>();
        _applicationRoleService = new ApplicationRoleService(_applicationRoleRepositoryMock.Object);
    }

    //Happy Test

    [Test]
    public async Task GetAllApplicationRolesAsync_ShouldReturnRoles_WhenRolesExist()
    {
        //Arrange
        var expectedRoles = new List<ApplicationRole>
        {
           new ApplicationRole
           {
               ApplicationRoleId = 1, Name="Front End Developer"
           },
           new ApplicationRole
            {
                ApplicationRoleId=2, Name="Back End Developer"
            }
        };
        _applicationRoleRepositoryMock.Setup(repo=>repo.GetAllApplicationRolesAsync()).ReturnsAsync(expectedRoles);

        //Act
        var result=await _applicationRoleService.GetAllApplicationRolesAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(expectedRoles.Count));
        Assert.That(result.First().Name, Is.EqualTo("Front End Developer"));
    }

    //Failure Test
    [Test]
    public async Task GetAllApplicationRolesAsync_ReturnsEmptyList_WhenNoActiveRoles()
    {
        // Arrange
        _applicationRoleRepositoryMock.Setup(repo => repo.GetAllApplicationRolesAsync())
                       .ReturnsAsync(new List<ApplicationRole>()); // Simulate no roles

        // Act
        var result = await _applicationRoleService.GetAllApplicationRolesAsync();

        // Assert
        Assert.IsNotNull(result);      // Ensure the result is not null
        Assert.IsEmpty(result);         // Ensure the result is an empty collection
    }

}

