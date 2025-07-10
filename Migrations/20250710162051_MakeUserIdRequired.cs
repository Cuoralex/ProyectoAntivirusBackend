using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectAntivirusBackend.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserIdRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "information",
                table: "institutions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "information",
                table: "institutions");
        }
    }
}
