using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class themDiaChiDoanhNghiep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DotThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "DotThanhToans");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans");

            migrationBuilder.AlterColumn<int>(
                name: "HinhThucThanhToanId",
                table: "ThanhToans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HinhThucThanhToanId",
                table: "DotThanhToans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "DoanhNghieps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiaChi",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_DotThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "DotThanhToans",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DotThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "DotThanhToans");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "DoanhNghieps");

            migrationBuilder.AlterColumn<int>(
                name: "HinhThucThanhToanId",
                table: "ThanhToans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HinhThucThanhToanId",
                table: "DotThanhToans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DotThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "DotThanhToans",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToans_HinhThucThanhToans_HinhThucThanhToanId",
                table: "ThanhToans",
                column: "HinhThucThanhToanId",
                principalTable: "HinhThucThanhToans",
                principalColumn: "Id");
        }
    }
}
