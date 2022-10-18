using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParticipationPortal.API.Migrations
{
    public partial class UpdateWeeklyEventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "starting_date",
                schema: "dbo",
                table: "weekly_event");

            migrationBuilder.AddColumn<int>(
                name: "day_of_week",
                schema: "dbo",
                table: "weekly_event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "dbo",
                table: "weekly_event",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "day_of_week",
                schema: "dbo",
                table: "weekly_event");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "dbo",
                table: "weekly_event");

            migrationBuilder.AddColumn<DateTime>(
                name: "starting_date",
                schema: "dbo",
                table: "weekly_event",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
