
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationHelper.Migrations
{
    public partial class ChangeInterviewIdAndAddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews");
            migrationBuilder.DropColumn(
                name: "id",
                table: "Interviews");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews",
                column: "id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Interviews");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "Interviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews",
                column: "id");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Interviews");
        }
    }
}
