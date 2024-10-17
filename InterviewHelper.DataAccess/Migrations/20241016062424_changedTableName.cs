using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewHelper.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScore_Technologie_TechnologyId",
                table: "CandidateTechnologyScore");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Technologie_TechnologyId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologie",
                table: "Technologie");

            migrationBuilder.RenameTable(
                name: "Technologie",
                newName: "Technology");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technology",
                table: "Technology",
                column: "TechnologyId");

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "ApplicationRoleId",
                keyValue: 3,
                column: "Name",
                value: "Database SQL");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScore_Technology_TechnologyId",
                table: "CandidateTechnologyScore",
                column: "TechnologyId",
                principalTable: "Technology",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Technology_TechnologyId",
                table: "Question",
                column: "TechnologyId",
                principalTable: "Technology",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechnologyScore_Technology_TechnologyId",
                table: "CandidateTechnologyScore");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Technology_TechnologyId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technology",
                table: "Technology");

            migrationBuilder.RenameTable(
                name: "Technology",
                newName: "Technologie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologie",
                table: "Technologie",
                column: "TechnologyId");

            migrationBuilder.UpdateData(
                table: "ApplicationRole",
                keyColumn: "ApplicationRoleId",
                keyValue: 3,
                column: "Name",
                value: "Database/SQL");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechnologyScore_Technologie_TechnologyId",
                table: "CandidateTechnologyScore",
                column: "TechnologyId",
                principalTable: "Technologie",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Technologie_TechnologyId",
                table: "Question",
                column: "TechnologyId",
                principalTable: "Technologie",
                principalColumn: "TechnologyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
