using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InterviewHelper.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    ApplicationRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.ApplicationRoleId);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLevels",
                columns: table => new
                {
                    ExperienceLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevels", x => x.ExperienceLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationRoleId = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OverallScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_Candidates_ApplicationRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "ApplicationRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevelId = table.Column<int>(type: "int", nullable: false),
                    ApplicationRoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_ApplicationRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "ApplicationRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_ExperienceLevels_ExperienceLevelId",
                        column: x => x.ExperienceLevelId,
                        principalTable: "ExperienceLevels",
                        principalColumn: "ExperienceLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTechnologyScores",
                columns: table => new
                {
                    CandidateTechnologyScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevelId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTechnologyScores", x => x.CandidateTechnologyScoreId);
                    table.ForeignKey(
                        name: "FK_CandidateTechnologyScores_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateTechnologyScores_ExperienceLevels_ExperienceLevelId",
                        column: x => x.ExperienceLevelId,
                        principalTable: "ExperienceLevels",
                        principalColumn: "ExperienceLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateTechnologyScores_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "TechnologyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "ApplicationRoleId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Front End Developer" },
                    { 2, true, "Back End Developer" },
                    { 3, true, "Database/SQL" }
                });

            migrationBuilder.InsertData(
                table: "ExperienceLevels",
                columns: new[] { "ExperienceLevelId", "IsActive", "Level" },
                values: new object[,]
                {
                    { 1, true, "Fresher" },
                    { 2, true, "Mid" },
                    { 3, true, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "TechnologyId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Angular" },
                    { 2, true, "React" },
                    { 3, true, "Vue.js" },
                    { 4, true, "Svelte" },
                    { 5, true, "HTML5" },
                    { 6, true, "CSS3" },
                    { 7, true, "JavaScript" },
                    { 8, true, "TypeScript" },
                    { 9, true, "Bootstrap" },
                    { 10, true, "TailwindCSS" },
                    { 11, true, "Angular Material" },
                    { 12, true, "Ant Design" },
                    { 13, true, "Chakra UI" },
                    { 14, true, "Node.js + Express" },
                    { 15, true, ".NET Core" },
                    { 16, true, "Django" },
                    { 17, true, "Flask" },
                    { 18, true, "Spring Boot" },
                    { 19, true, "Ruby on Rails" },
                    { 20, true, "PHP + Laravel" },
                    { 21, true, "PostgreSQL" },
                    { 22, true, "MySQL" },
                    { 23, true, "MariaDB" },
                    { 24, true, "SQLite" },
                    { 25, true, "Microsoft SQL Server" },
                    { 26, true, "MongoDB" },
                    { 27, true, "Firebase" },
                    { 28, true, "Cassandra" },
                    { 29, true, "Redis" },
                    { 30, true, "Neo4j" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "ApplicationRoleId", "ExperienceLevelId", "IsActive", "TechnologyId", "Text" },
                values: new object[,]
                {
                    { 1, 1, 2, true, 1, "What is Angular Dependency Injection?" },
                    { 2, 1, 2, true, 1, "Explain Angular Component Lifecycle." },
                    { 3, 1, 2, true, 1, "How does Change Detection work in Angular?" },
                    { 4, 1, 2, true, 1, "What are Angular Services?" },
                    { 5, 1, 2, true, 1, "Explain Angular Pipes." },
                    { 6, 1, 2, true, 1, "What is NgZone in Angular?" },
                    { 7, 1, 2, true, 1, "What is the difference between ngIf and hidden in Angular?" },
                    { 8, 1, 2, true, 1, "What are Angular Directives?" },
                    { 9, 1, 2, true, 1, "Explain how Angular CLI works." },
                    { 10, 1, 2, true, 1, "How do you optimize performance in Angular?" },
                    { 11, 1, 1, true, 2, "What is JSX in React?" },
                    { 12, 1, 1, true, 2, "Explain React Components." },
                    { 13, 1, 1, true, 2, "What are React Hooks?" },
                    { 14, 1, 1, true, 2, "What is the Virtual DOM in React?" },
                    { 15, 1, 1, true, 2, "How do you handle events in React?" },
                    { 16, 1, 1, true, 2, "What is a React Fragment?" },
                    { 17, 1, 1, true, 2, "What are Props in React?" },
                    { 18, 1, 1, true, 2, "How does state management work in React?" },
                    { 19, 1, 1, true, 2, "What are Higher-Order Components in React?" },
                    { 20, 1, 1, true, 2, "What is the difference between state and props?" },
                    { 21, 1, 3, true, 7, "What is hoisting in JavaScript?" },
                    { 22, 1, 3, true, 7, "Explain closures in JavaScript." },
                    { 23, 1, 3, true, 7, "What is event delegation in JavaScript?" },
                    { 24, 1, 3, true, 7, "How do JavaScript Promises work?" },
                    { 25, 1, 3, true, 7, "What is the event loop in JavaScript?" },
                    { 26, 1, 3, true, 7, "What is the difference between let and var?" },
                    { 27, 1, 3, true, 7, "How does async/await work in JavaScript?" },
                    { 28, 1, 3, true, 7, "What is a JavaScript module?" },
                    { 29, 1, 3, true, 7, "Explain JavaScript destructuring." },
                    { 30, 1, 3, true, 7, "What is the Temporal Dead Zone in JavaScript?" },
                    { 31, 1, 1, true, 3, "What is Vue.js?" },
                    { 32, 1, 1, true, 3, "Explain Vue.js Components." },
                    { 33, 1, 1, true, 4, "What is Svelte?" },
                    { 34, 1, 1, true, 4, "Explain Svelte's reactivity model." },
                    { 35, 1, 1, true, 5, "Explain the key features of Java." },
                    { 36, 1, 1, true, 5, "What are Java streams?" },
                    { 37, 1, 1, true, 6, "What is the purpose of Rust’s ownership model?" },
                    { 38, 1, 1, true, 6, "Explain Rust’s memory safety." },
                    { 39, 1, 2, true, 8, "What is functional programming?" },
                    { 40, 1, 2, true, 8, "Explain higher-order functions in functional programming." },
                    { 41, 1, 2, true, 3, "What are Vue Directives?" },
                    { 42, 1, 2, true, 3, "How does Vue.js handle state management?" },
                    { 43, 1, 3, true, 3, "Explain Vue Router and its usage." },
                    { 44, 1, 3, true, 3, "What is Vuex and how does it work?" },
                    { 45, 1, 2, true, 4, "What is the Svelte Store?" },
                    { 46, 1, 2, true, 4, "How do you handle forms in Svelte?" },
                    { 47, 1, 3, true, 4, "Explain the reactivity mechanism in Svelte." },
                    { 48, 1, 3, true, 4, "How do transitions and animations work in Svelte?" },
                    { 49, 1, 2, true, 5, "What is the difference between HashMap and Hashtable?" },
                    { 50, 1, 2, true, 5, "Explain Java garbage collection." },
                    { 51, 1, 3, true, 5, "What is the significance of the `volatile` keyword in Java?" },
                    { 52, 1, 3, true, 5, "Explain how memory management works in Java." },
                    { 53, 1, 2, true, 6, "What is the borrow checker in Rust?" },
                    { 54, 1, 2, true, 6, "How do Rust traits work?" },
                    { 55, 1, 3, true, 6, "Explain the difference between `Box`, `Rc`, and `Arc` in Rust." },
                    { 56, 1, 3, true, 6, "How does Rust ensure memory safety without garbage collection?" },
                    { 57, 1, 3, true, 8, "What is the significance of immutability in functional programming?" },
                    { 58, 1, 3, true, 8, "Explain how recursion is handled in functional programming." },
                    { 59, 1, 1, true, 9, "What is the difference between a list and a tuple in Python?" },
                    { 60, 1, 1, true, 9, "What are Python decorators?" },
                    { 61, 1, 2, true, 9, "Explain how list comprehensions work in Python." },
                    { 62, 1, 2, true, 9, "What is a generator in Python?" },
                    { 63, 1, 3, true, 9, "Explain Python's Global Interpreter Lock (GIL)." },
                    { 64, 1, 3, true, 9, "How does memory management work in Python?" },
                    { 65, 1, 1, true, 10, "What is the difference between value type and reference type in C#?" },
                    { 66, 1, 1, true, 10, "Explain how exception handling works in C#." },
                    { 67, 1, 2, true, 10, "What are C# delegates?" },
                    { 68, 1, 2, true, 10, "What is LINQ in C#?" },
                    { 69, 1, 3, true, 10, "Explain async/await in C# and how it compares to other languages." },
                    { 70, 1, 3, true, 10, "How does garbage collection work in C#?" },
                    { 71, 1, 1, true, 1, "What is Angular's Dependency Injection?" },
                    { 72, 1, 1, true, 1, "How do you create reusable components in Angular?" },
                    { 73, 1, 3, true, 1, "What is Angular Universal and how does it handle server-side rendering?" },
                    { 74, 1, 3, true, 1, "How do you optimize the performance of an Angular application?" },
                    { 75, 1, 2, true, 2, "What is the use of `useEffect` in React?" },
                    { 76, 1, 2, true, 2, "Explain how React handles state with `useState`." },
                    { 77, 1, 3, true, 2, "What is React Server Components?" },
                    { 78, 1, 3, true, 2, "Explain Context API in React and how it is used." },
                    { 79, 1, 1, true, 7, "What are JavaScript data types?" },
                    { 80, 1, 1, true, 7, "Explain the difference between `var`, `let`, and `const` in JavaScript." },
                    { 81, 1, 2, true, 7, "Explain how `async` and `await` work in JavaScript." },
                    { 82, 1, 2, true, 7, "What are JavaScript Promises and how are they used?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ApplicationRoleId",
                table: "Candidates",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechnologyScores_CandidateId",
                table: "CandidateTechnologyScores",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechnologyScores_ExperienceLevelId",
                table: "CandidateTechnologyScores",
                column: "ExperienceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechnologyScores_TechnologyId",
                table: "CandidateTechnologyScores",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ApplicationRoleId",
                table: "Questions",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExperienceLevelId",
                table: "Questions",
                column: "ExperienceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TechnologyId",
                table: "Questions",
                column: "TechnologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateTechnologyScores");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "ExperienceLevels");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");
        }
    }
}
