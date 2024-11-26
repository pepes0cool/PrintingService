using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSPS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddpaperBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaperBalance",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaperBalance",
                table: "AspNetUsers");
        }
    }
}
