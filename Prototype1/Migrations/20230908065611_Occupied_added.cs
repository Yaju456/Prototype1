using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prototype1.Migrations
{
    /// <inheritdoc />
    public partial class Occupied_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "occupied",
                table: "ShowDate",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "occupied",
                table: "ShowDate");
        }
    }
}
