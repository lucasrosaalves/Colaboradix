using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colaboradix.Infra.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(220)", maxLength: 220, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cycles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    from = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    to = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    team_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cycles", x => x.id);
                    table.ForeignKey(
                        name: "fk_cycles_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)2),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    team_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_members", x => x.id);
                    table.ForeignKey(
                        name: "fk_members_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    quantity = table.Column<byte>(type: "smallint", maxLength: 3, nullable: false),
                    sender_id = table.Column<Guid>(type: "uuid", nullable: false),
                    receiver_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cycle_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "fk_feedbacks_cycles_cycle_id",
                        column: x => x.cycle_id,
                        principalTable: "cycles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_feedbacks_members_receiver_id",
                        column: x => x.receiver_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_feedbacks_members_sender_id",
                        column: x => x.sender_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cycles_team_id",
                table: "cycles",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_cycle_id",
                table: "feedbacks",
                column: "cycle_id");

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_receiver_id",
                table: "feedbacks",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "ix_feedbacks_sender_id",
                table: "feedbacks",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "ix_members_team_id",
                table: "members",
                column: "team_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "cycles");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
