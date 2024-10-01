using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewHelper.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class interviewHelperv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "ApplicationRoleId",
                keyValue: 3,
                column: "Name",
                value: "Database/SQL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "Candidates");

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "ApplicationRoleId",
                keyValue: 3,
                column: "Name",
                value: "Database/SQl");
        }
    }
}
