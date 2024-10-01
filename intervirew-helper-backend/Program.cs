using intervirew_helper_backend.Repository.IRepository;
using intervirew_helper_backend.Repository;
using intervirew_helper_backend.services.IServices;
using Microsoft.EntityFrameworkCore;
using intervirew_helper_backend.services;
using InterviewHelper.DataAccess.Repository.IRepository;
using InterviewHelper.DataAccess.Repository;
using InterviewHelper.Business.services.IServices;
using InterviewHelper.Business.services;
using InterviewHelper.Business.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<InterviewAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure JSON options to handle circular references
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add repositories and services
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IApplicationRoleRepository, ApplicationRoleRepository>();
builder.Services.AddScoped<IApplicationRoleService, ApplicationRoleService>();
builder.Services.AddScoped<IExperienceLevelRepository, ExperienceLevelRepository>();
builder.Services.AddScoped<IExperienceLevelService, ExperienceLevelService>();
builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<ITechnologyService, TechnologyService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS policy to allow requests from Angular app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") // Allow Angular app origin
            .AllowAnyMethod()                      // Allow any HTTP method
            .AllowAnyHeader()                      // Allow any headers
            .AllowCredentials());                  // Allow credentials if needed (optional)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp"); // Use the CORS policy

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
