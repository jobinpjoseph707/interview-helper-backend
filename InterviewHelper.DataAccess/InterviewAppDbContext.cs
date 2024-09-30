using intervirew_helper_backend.Models;
using Microsoft.EntityFrameworkCore;

public class InterviewAppDbContext : DbContext
{
    public InterviewAppDbContext(DbContextOptions<InterviewAppDbContext> options) : base(options) { }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
    public DbSet<CandidateTechnologyScore> CandidateTechnologyScores { get; set; }
    public DbSet<Question> Questions { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints

        modelBuilder.Entity<Candidate>()
            .HasOne(c => c.ApplicationRole)
            .WithMany(ar => ar.Candidates)
            .HasForeignKey(c => c.ApplicationRoleId);

        modelBuilder.Entity<CandidateTechnologyScore>()
            .HasOne(cts => cts.Candidate)
            .WithMany(c => c.CandidateTechnologyScores)
            .HasForeignKey(cts => cts.CandidateId);

        modelBuilder.Entity<CandidateTechnologyScore>()
            .HasOne(cts => cts.Technology)
            .WithMany(t => t.CandidateTechnologyScores)
            .HasForeignKey(cts => cts.TechnologyId);

        modelBuilder.Entity<CandidateTechnologyScore>()
            .HasOne(cts => cts.ExperienceLevel)
            .WithMany(el => el.CandidateTechnologyScores)
            .HasForeignKey(cts => cts.ExperienceLevelId);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.Technology)
            .WithMany(t => t.Questions)
            .HasForeignKey(q => q.TechnologyId);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.ExperienceLevel)
            .WithMany(el => el.Questions)
            .HasForeignKey(q => q.ExperienceLevelId);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.ApplicationRole)
            .WithMany(ar => ar.Questions)
            .HasForeignKey(q => q.ApplicationRoleId);


        base.OnModelCreating(modelBuilder);

        // Seeding data
        modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole { ApplicationRoleId = 1, Name = "Front End Developer", IsActive = true },
            new ApplicationRole { ApplicationRoleId = 2, Name = "Back End Developer", IsActive = true },
            new ApplicationRole { ApplicationRoleId = 3, Name = "Database/SQL", IsActive = true }
        );
        modelBuilder.Entity<ExperienceLevel>().HasData(
            new ExperienceLevel { ExperienceLevelId = 1, Level = "Fresher", IsActive = true },
            new ExperienceLevel { ExperienceLevelId = 2, Level = "Mid", IsActive = true },
            new ExperienceLevel { ExperienceLevelId = 3, Level = "Senior", IsActive = true }
            );


        // Seeding Technology data
        modelBuilder.Entity<Technology>().HasData(
            new Technology { TechnologyId = 1, Name = "Angular", IsActive = true },
            new Technology { TechnologyId = 2, Name = "React", IsActive = true },
            new Technology { TechnologyId = 3, Name = "Vue.js", IsActive = true },
            new Technology { TechnologyId = 4, Name = "Svelte", IsActive = true },
            new Technology { TechnologyId = 5, Name = "HTML5", IsActive = true },
            new Technology { TechnologyId = 6, Name = "CSS3", IsActive = true },
            new Technology { TechnologyId = 7, Name = "JavaScript", IsActive = true },
            new Technology { TechnologyId = 8, Name = "TypeScript", IsActive = true },
            new Technology { TechnologyId = 9, Name = "Bootstrap", IsActive = true },
            new Technology { TechnologyId = 10, Name = "TailwindCSS", IsActive = true },
            new Technology { TechnologyId = 11, Name = "Angular Material", IsActive = true },
            new Technology { TechnologyId = 12, Name = "Ant Design", IsActive = true },
            new Technology { TechnologyId = 13, Name = "Chakra UI", IsActive = true },
            new Technology { TechnologyId = 14, Name = "Node.js + Express", IsActive = true },
            new Technology { TechnologyId = 15, Name = ".NET Core", IsActive = true },
            new Technology { TechnologyId = 16, Name = "Django", IsActive = true },
            new Technology { TechnologyId = 17, Name = "Flask", IsActive = true },
            new Technology { TechnologyId = 18, Name = "Spring Boot", IsActive = true },
            new Technology { TechnologyId = 19, Name = "Ruby on Rails", IsActive = true },
            new Technology { TechnologyId = 20, Name = "PHP + Laravel", IsActive = true },
            new Technology { TechnologyId = 21, Name = "PostgreSQL", IsActive = true },
            new Technology { TechnologyId = 22, Name = "MySQL", IsActive = true },
            new Technology { TechnologyId = 23, Name = "MariaDB", IsActive = true },
            new Technology { TechnologyId = 24, Name = "SQLite", IsActive = true },
            new Technology { TechnologyId = 25, Name = "Microsoft SQL Server", IsActive = true },
            new Technology { TechnologyId = 26, Name = "MongoDB", IsActive = true },
            new Technology { TechnologyId = 27, Name = "Firebase", IsActive = true },
            new Technology { TechnologyId = 28, Name = "Cassandra", IsActive = true },
            new Technology { TechnologyId = 29, Name = "Redis", IsActive = true },
            new Technology { TechnologyId = 30, Name = "Neo4j", IsActive = true }
        );
    }


}

