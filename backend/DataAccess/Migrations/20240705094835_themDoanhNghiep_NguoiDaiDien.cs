using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class themDoanhNghiep_NguoiDaiDien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NguoiDaiDien",
                table: "DoanhNghieps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DiaChi", "Image", "NguoiDaiDien" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiaChi", "Image", "NguoiDaiDien" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DiaChi", "Image", "NguoiDaiDien" },
                values: new object[] { "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NguoiDaiDien",
                table: "DoanhNghieps");

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DiaChi", "Image" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiaChi", "Image" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DiaChi", "Image" },
                values: new object[] { null, null });
        }
    }
}
