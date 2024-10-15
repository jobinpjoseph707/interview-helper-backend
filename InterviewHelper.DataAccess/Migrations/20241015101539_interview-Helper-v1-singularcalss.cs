using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewHelper.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class interviewHelperv1singularcalss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_ApplicationRoles_ApplicationRoleId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScores_Candidates_CandidateId",
                table: "CandidateTechnologyScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScores_ExperienceLevels_ExperienceLevelId",
                table: "CandidateTechnologyScores");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScores_Technologies_TechnologyId",
                table: "CandidateTechnologyScores");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ApplicationRoles_ApplicationRoleId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ExperienceLevels_ExperienceLevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Technologies_TechnologyId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperienceLevels",
                table: "ExperienceLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateTechnologyScores",
                table: "CandidateTechnologyScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationRoles",
                table: "ApplicationRoles");

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "Technologie");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "ExperienceLevels",
                newName: "ExperienceLevel");

            migrationBuilder.RenameTable(
                name: "CandidateTechnologyScores",
                newName: "CandidateTechnologyScore");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "Candidate");

            migrationBuilder.RenameTable(
                name: "ApplicationRoles",
                newName: "ApplicationRole");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TechnologyId",
                table: "Question",
                newName: "IX_Question_TechnologyId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ExperienceLevelId",
                table: "Question",
                newName: "IX_Question_ExperienceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_ApplicationRoleId",
                table: "Question",
                newName: "IX_Question_ApplicationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTechnologyScores_TechnologyId",
                table: "CandidateTechnologyScore",
                newName: "IX_CandidateTechnologyScore_TechnologyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTechnologyScores_ExperienceLevelId",
                table: "CandidateTechnologyScore",
                newName: "IX_CandidateTechnologyScore_ExperienceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTechnologyScores_CandidateId",
                table: "CandidateTechnologyScore",
                newName: "IX_CandidateTechnologyScore_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_ApplicationRoleId",
                table: "Candidate",
                newName: "IX_Candidate_ApplicationRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologie",
                table: "Technologie",
                column: "TechnologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperienceLevel",
                table: "ExperienceLevel",
                column: "ExperienceLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateTechnologyScore",
                table: "CandidateTechnologyScore",
                column: "CandidateTechnologyScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationRole",
                table: "ApplicationRole",
                column: "ApplicationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_ApplicationRole_ApplicationRoleId",
                table: "Candidate",
                column: "ApplicationRoleId",
                principalTable: "ApplicationRole",
                principalColumn: "ApplicationRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScore_Candidate_CandidateId",
                table: "CandidateTechnologyScore",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScore_ExperienceLevel_ExperienceLevelId",
                table: "CandidateTechnologyScore",
                column: "ExperienceLevelId",
                principalTable: "ExperienceLevel",
                principalColumn: "ExperienceLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScore_Technologie_TechnologyId",
                table: "CandidateTechnologyScore",
                column: "TechnologyId",
                principalTable: "Technologie",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ApplicationRole_ApplicationRoleId",
                table: "Question",
                column: "ApplicationRoleId",
                principalTable: "ApplicationRole",
                principalColumn: "ApplicationRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_ExperienceLevel_ExperienceLevelId",
                table: "Question",
                column: "ExperienceLevelId",
                principalTable: "ExperienceLevel",
                principalColumn: "ExperienceLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Technologie_TechnologyId",
                table: "Question",
                column: "TechnologyId",
                principalTable: "Technologie",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_ApplicationRole_ApplicationRoleId",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScore_Candidate_CandidateId",
                table: "CandidateTechnologyScore");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScore_ExperienceLevel_ExperienceLevelId",
                table: "CandidateTechnologyScore");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScore_Technologie_TechnologyId",
                table: "CandidateTechnologyScore");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ApplicationRole_ApplicationRoleId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_ExperienceLevel_ExperienceLevelId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Technologie_TechnologyId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologie",
                table: "Technologie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExperienceLevel",
                table: "ExperienceLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateTechnologyScore",
                table: "CandidateTechnologyScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationRole",
                table: "ApplicationRole");

            migrationBuilder.RenameTable(
                name: "Technologie",
                newName: "Technologies");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "ExperienceLevel",
                newName: "ExperienceLevels");

            migrationBuilder.RenameTable(
                name: "CandidateTechnologyScore",
                newName: "CandidateTechnologyScores");

            migrationBuilder.RenameTable(
                name: "Candidate",
                newName: "Candidates");

            migrationBuilder.RenameTable(
                name: "ApplicationRole",
                newName: "ApplicationRoles");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TechnologyId",
                table: "Questions",
                newName: "IX_Questions_TechnologyId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_ExperienceLevelId",
                table: "Questions",
                newName: "IX_Questions_ExperienceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_ApplicationRoleId",
                table: "Questions",
                newName: "IX_Questions_ApplicationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTechnologyScore_TechnologyId",
                table: "CandidateTechnologyScores",
                newName: "IX_CandidateTechnologyScores_TechnologyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTechnologyScore_ExperienceLevelId",
                table: "CandidateTechnologyScores",
                newName: "IX_CandidateTechnologyScores_ExperienceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateTechnologyScore_CandidateId",
                table: "CandidateTechnologyScores",
                newName: "IX_CandidateTechnologyScores_CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_ApplicationRoleId",
                table: "Candidates",
                newName: "IX_Candidates_ApplicationRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "TechnologyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExperienceLevels",
                table: "ExperienceLevels",
                column: "ExperienceLevelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateTechnologyScores",
                table: "CandidateTechnologyScores",
                column: "CandidateTechnologyScoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationRoles",
                table: "ApplicationRoles",
                column: "ApplicationRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_ApplicationRoles_ApplicationRoleId",
                table: "Candidates",
                column: "ApplicationRoleId",
                principalTable: "ApplicationRoles",
                principalColumn: "ApplicationRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScores_Candidates_CandidateId",
                table: "CandidateTechnologyScores",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScores_ExperienceLevels_ExperienceLevelId",
                table: "CandidateTechnologyScores",
                column: "ExperienceLevelId",
                principalTable: "ExperienceLevels",
                principalColumn: "ExperienceLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScores_Technologies_TechnologyId",
                table: "CandidateTechnologyScores",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ApplicationRoles_ApplicationRoleId",
                table: "Questions",
                column: "ApplicationRoleId",
                principalTable: "ApplicationRoles",
                principalColumn: "ApplicationRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ExperienceLevels_ExperienceLevelId",
                table: "Questions",
                column: "ExperienceLevelId",
                principalTable: "ExperienceLevels",
                principalColumn: "ExperienceLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Technologies_TechnologyId",
                table: "Questions",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
