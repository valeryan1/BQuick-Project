using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BQuick.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMeetingRequestDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedDateTime",
                table: "MeetingRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingEndTime",
                table: "MeetingRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingStartTime",
                table: "MeetingRequests",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingEndTime",
                table: "MeetingRequests");

            migrationBuilder.DropColumn(
                name: "MeetingStartTime",
                table: "MeetingRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDateTime",
                table: "MeetingRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
