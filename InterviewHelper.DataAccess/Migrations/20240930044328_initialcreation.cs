using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InterviewHelper.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialcreation : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.TechnologyId);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationRoleId = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OverallScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 3, true, "Database/SQl" }
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
