using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prototype1.Migrations
{
    /// <inheritdoc />
    public partial class FirstTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imgurl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "showTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTickets = table.Column<int>(type: "int", nullable: false),
                    soldTickets = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_showTickets_Show_ShowID",
                        column: x => x.ShowID,
                        principalTable: "Show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowDate",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTicketID = table.Column<int>(type: "int", nullable: false),
                    Qrvalue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checked = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowDate", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_ShowDate_showTickets_ShowTicketID",
                        column: x => x.ShowTicketID,
                        principalTable: "showTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowDate_ShowTicketID",
                table: "ShowDate",
                column: "ShowTicketID");

            migrationBuilder.CreateIndex(
                name: "IX_showTickets_ShowID",
                table: "showTickets",
                column: "ShowID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowDate");

            migrationBuilder.DropTable(
                name: "showTickets");

            migrationBuilder.DropTable(
                name: "Show");
        }
    }
}
