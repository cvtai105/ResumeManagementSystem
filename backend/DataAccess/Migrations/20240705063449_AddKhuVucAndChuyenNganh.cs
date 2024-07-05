using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddKhuVucAndChuyenNganh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans");

            migrationBuilder.AlterColumn<int>(
                name: "HinhThucThanhToanId",
                table: "ThanhToans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ChuyenNganh",
                table: "DangTuyens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhuVuc",
                table: "DangTuyens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChuyenNganh", "KhuVuc" },
                values: new object[] { "IT", "Hà Nội" });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ChuyenNganh", "KhuVuc" },
                values: new object[] { "Kế Toán", "Hà Nội" });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ChuyenNganh", "KhuVuc" },
                values: new object[] { "Kinh Doanh", "Hồ Chi Minh" });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ChuyenNganh", "KhuVuc" },
                values: new object[] { "Kinh Doanh", "Hồ Chi Minh" });

            migrationBuilder.UpdateData(
                table: "DangTuyens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ChuyenNganh", "KhuVuc" },
                values: new object[] { "Kinh Doanh", "Hồ Chi Minh" });

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans");

            migrationBuilder.DropColumn(
                name: "ChuyenNganh",
                table: "DangTuyens");

            migrationBuilder.DropColumn(
                name: "KhuVuc",
                table: "DangTuyens");

            migrationBuilder.AlterColumn<int>(
                name: "HinhThucThanhToanId",
                table: "ThanhToans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
