using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParticipationPortal.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    icon_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "weekly_event",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    starting_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weekly_event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    firebase_user_id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    insert_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "incoming_event",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weekly_event_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    actual_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incoming_event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incoming_event_weekly_event_weekly_event_id",
                        column: x => x.weekly_event_id,
                        principalSchema: "dbo",
                        principalTable: "weekly_event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "incoming_event_role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    incoming_event_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    is_covered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incoming_event_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incoming_event_role_incoming_event_incoming_event_id",
                        column: x => x.incoming_event_id,
                        principalSchema: "dbo",
                        principalTable: "incoming_event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_incoming_event_role_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "incoming_event_user",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    incoming_event_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_participating = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incoming_event_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incoming_event_user_incoming_event_incoming_event_id",
                        column: x => x.incoming_event_id,
                        principalSchema: "dbo",
                        principalTable: "incoming_event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_incoming_event_user_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "dbo",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_incoming_event_weekly_event_id",
                schema: "dbo",
                table: "incoming_event",
                column: "weekly_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_incoming_event_role_incoming_event_id",
                schema: "dbo",
                table: "incoming_event_role",
                column: "incoming_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_incoming_event_role_role_id",
                schema: "dbo",
                table: "incoming_event_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_incoming_event_user_incoming_event_id",
                schema: "dbo",
                table: "incoming_event_user",
                column: "incoming_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_incoming_event_user_user_id",
                schema: "dbo",
                table: "incoming_event_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id",
                schema: "dbo",
                table: "user",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incoming_event_role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "incoming_event_user",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "incoming_event",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "user",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "weekly_event",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "role",
                schema: "dbo");
        }
    }
}
