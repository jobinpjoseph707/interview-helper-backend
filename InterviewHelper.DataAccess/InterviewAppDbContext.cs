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
    public DbSet<User> User{ get; set; }



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
            new ApplicationRole { ApplicationRoleId = 3, Name = "Database SQL", IsActive = true }
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
        modelBuilder.Entity<Question>().HasData(
    // Angular (Mid-level)
    new Question { QuestionId = 1, Text = "What is Angular Dependency Injection?", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 2, Text = "Explain Angular Component Lifecycle.", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 3, Text = "How does Change Detection work in Angular?", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 4, Text = "What are Angular Services?", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 5, Text = "Explain Angular Pipes.", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 6, Text = "What is NgZone in Angular?", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 7, Text = "What is the difference between ngIf and hidden in Angular?", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 8, Text = "What are Angular Directives?", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 9, Text = "Explain how Angular CLI works.", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 10, Text = "How do you optimize performance in Angular?", TechnologyId = 1, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

    // React (Fresher)
    new Question { QuestionId = 11, Text = "What is JSX in React?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 12, Text = "Explain React Components.", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 13, Text = "What are React Hooks?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 14, Text = "What is the Virtual DOM in React?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 15, Text = "How do you handle events in React?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 16, Text = "What is a React Fragment?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 17, Text = "What are Props in React?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 18, Text = "How does state management work in React?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 19, Text = "What are Higher-Order Components in React?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 20, Text = "What is the difference between state and props?", TechnologyId = 2, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },

    // JavaScript (Senior)
    new Question { QuestionId = 21, Text = "What is hoisting in JavaScript?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 22, Text = "Explain closures in JavaScript.", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 23, Text = "What is event delegation in JavaScript?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 24, Text = "How do JavaScript Promises work?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 25, Text = "What is the event loop in JavaScript?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 26, Text = "What is the difference between let and var?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 27, Text = "How does async/await work in JavaScript?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 28, Text = "What is a JavaScript module?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 29, Text = "Explain JavaScript destructuring.", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 30, Text = "What is the Temporal Dead Zone in JavaScript?", TechnologyId = 7, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

    // Other Technology and Experience Level combinations with 2 questions each
    new Question { QuestionId = 31, Text = "What is Vue.js?", TechnologyId = 3, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 32, Text = "Explain Vue.js Components.", TechnologyId = 3, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 33, Text = "What is Svelte?", TechnologyId = 4, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 34, Text = "Explain Svelte's reactivity model.", TechnologyId = 4, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 35, Text = "Explain the key features of Java.", TechnologyId = 5, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 36, Text = "What are Java streams?", TechnologyId = 5, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 37, Text = "What is the purpose of Rust’s ownership model?", TechnologyId = 6, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 38, Text = "Explain Rust’s memory safety.", TechnologyId = 6, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },

    new Question { QuestionId = 39, Text = "What is functional programming?", TechnologyId = 8, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
    new Question { QuestionId = 40, Text = "Explain higher-order functions in functional programming.", TechnologyId = 8, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

// Vue.js (Mid-level)
new Question { QuestionId = 41, Text = "What are Vue Directives?", TechnologyId = 3, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 42, Text = "How does Vue.js handle state management?", TechnologyId = 3, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

// Vue.js (Senior)
new Question { QuestionId = 43, Text = "Explain Vue Router and its usage.", TechnologyId = 3, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 44, Text = "What is Vuex and how does it work?", TechnologyId = 3, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

// Svelte (Mid-level)
new Question { QuestionId = 45, Text = "What is the Svelte Store?", TechnologyId = 4, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 46, Text = "How do you handle forms in Svelte?", TechnologyId = 4, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

// Svelte (Senior)
new Question { QuestionId = 47, Text = "Explain the reactivity mechanism in Svelte.", TechnologyId = 4, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 48, Text = "How do transitions and animations work in Svelte?", TechnologyId = 4, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

// Java (Mid-level)
new Question { QuestionId = 49, Text = "What is the difference between HashMap and Hashtable?", TechnologyId = 5, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 50, Text = "Explain Java garbage collection.", TechnologyId = 5, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

// Java (Senior)
new Question { QuestionId = 51, Text = "What is the significance of the `volatile` keyword in Java?", TechnologyId = 5, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 52, Text = "Explain how memory management works in Java.", TechnologyId = 5, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

// Rust (Mid-level)
new Question { QuestionId = 53, Text = "What is the borrow checker in Rust?", TechnologyId = 6, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 54, Text = "How do Rust traits work?", TechnologyId = 6, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

// Rust (Senior)
new Question { QuestionId = 55, Text = "Explain the difference between `Box`, `Rc`, and `Arc` in Rust.", TechnologyId = 6, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 56, Text = "How does Rust ensure memory safety without garbage collection?", TechnologyId = 6, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

// Functional Programming (Senior)
new Question { QuestionId = 57, Text = "What is the significance of immutability in functional programming?", TechnologyId = 8, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 58, Text = "Explain how recursion is handled in functional programming.", TechnologyId = 8, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

// Python (Fresher)
new Question { QuestionId = 59, Text = "What is the difference between a list and a tuple in Python?", TechnologyId = 9, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 60, Text = "What are Python decorators?", TechnologyId = 9, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },

// Python (Mid-level)
new Question { QuestionId = 61, Text = "Explain how list comprehensions work in Python.", TechnologyId = 9, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 62, Text = "What is a generator in Python?", TechnologyId = 9, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

// Python (Senior)
new Question { QuestionId = 63, Text = "Explain Python's Global Interpreter Lock (GIL).", TechnologyId = 9, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 64, Text = "How does memory management work in Python?", TechnologyId = 9, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

// C# (Fresher)
new Question { QuestionId = 65, Text = "What is the difference between value type and reference type in C#?", TechnologyId = 10, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 66, Text = "Explain how exception handling works in C#.", TechnologyId = 10, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },

// C# (Mid-level)
new Question { QuestionId = 67, Text = "What are C# delegates?", TechnologyId = 10, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 68, Text = "What is LINQ in C#?", TechnologyId = 10, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },

// C# (Senior)
new Question { QuestionId = 69, Text = "Explain async/await in C# and how it compares to other languages.", TechnologyId = 10, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 70, Text = "How does garbage collection work in C#?", TechnologyId = 10, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },





new Question { QuestionId = 71, Text = "What is Angular's Dependency Injection?", TechnologyId = 1, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 72, Text = "How do you create reusable components in Angular?", TechnologyId = 1, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 73, Text = "What is Angular Universal and how does it handle server-side rendering?", TechnologyId = 1, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 74, Text = "How do you optimize the performance of an Angular application?", TechnologyId = 1, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },

new Question { QuestionId = 75, Text = "What is the use of `useEffect` in React?", TechnologyId = 2, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 76, Text = "Explain how React handles state with `useState`.", TechnologyId = 2, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 77, Text = "What is React Server Components?", TechnologyId = 2, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 78, Text = "Explain Context API in React and how it is used.", TechnologyId = 2, ExperienceLevelId = 3, ApplicationRoleId = 1, IsActive = true },


new Question { QuestionId = 79, Text = "What are JavaScript data types?", TechnologyId = 7, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 80, Text = "Explain the difference between `var`, `let`, and `const` in JavaScript.", TechnologyId = 7, ExperienceLevelId = 1, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 81, Text = "Explain how `async` and `await` work in JavaScript.", TechnologyId = 7, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true },
new Question { QuestionId = 82, Text = "What are JavaScript Promises and how are they used?", TechnologyId = 7, ExperienceLevelId = 2, ApplicationRoleId = 1, IsActive = true }




);

    }


}

