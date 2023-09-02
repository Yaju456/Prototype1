using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prototype1.Migrations
{
    /// <inheritdoc />
    public partial class change_in_showDateclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ticketno",
                table: "ShowDate",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ticketno",
                table: "ShowDate");
        }
    }
}
