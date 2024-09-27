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
    }
}
