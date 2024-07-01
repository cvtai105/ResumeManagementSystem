using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class xoatentieuchi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenTieuChi",
                table: "TieuChiTuyenDungs");

            migrationBuilder.CreateTable(
                name: "ExampleDTOs",
                columns: table => new
                {
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleDTOs");

            migrationBuilder.AddColumn<string>(
                name: "TenTieuChi",
                table: "TieuChiTuyenDungs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
