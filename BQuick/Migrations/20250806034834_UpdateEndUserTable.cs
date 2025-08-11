using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BQuick.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEndUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "CustomerContactPersons",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "JobPosition",
                table: "CustomerContactPersons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "CustomerContactPersons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CustomerContactPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "CustomerContactPersons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobPosition",
                table: "CustomerContactPersons");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "CustomerContactPersons");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CustomerContactPersons");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "CustomerContactPersons");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CustomerContactPersons",
                newName: "Position");
        }
    }
}
