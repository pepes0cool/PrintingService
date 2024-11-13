using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSPS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class firstprinter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "printers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paperNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_printers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "printers",
                columns: new[] { "Id", "Model", "Name", "SerialNumber", "paperNumber" },
                values: new object[] { 1, "Model1", "Printer1", "SerialNumber1", 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "printers");
        }
    }
}
