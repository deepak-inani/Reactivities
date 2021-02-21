using Microsoft.EntityFrameworkCore.Migrations;

namespace Reactivities.Persistence.Migrations
{
    public partial class AddDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activies",
                table: "Activies");

            migrationBuilder.RenameTable(
                name: "Activies",
                newName: "Activities");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activies",
                table: "Activies",
                column: "Id");
        }
    }
}
