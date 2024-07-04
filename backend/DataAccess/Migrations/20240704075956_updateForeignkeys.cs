using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateForeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoanhNghieps_NhanViens_NhanVien",
                table: "DoanhNghieps");

            migrationBuilder.DropIndex(
                name: "IX_DoanhNghieps_NhanVien",
                table: "DoanhNghieps");

            migrationBuilder.DropColumn(
                name: "NhanVien",
                table: "DoanhNghieps");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghieps_NhanVienDangKyId",
                table: "DoanhNghieps",
                column: "NhanVienDangKyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoanhNghieps_NhanViens_NhanVienDangKyId",
                table: "DoanhNghieps",
                column: "NhanVienDangKyId",
                principalTable: "NhanViens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoanhNghieps_NhanViens_NhanVienDangKyId",
                table: "DoanhNghieps");

            migrationBuilder.DropIndex(
                name: "IX_DoanhNghieps_NhanVienDangKyId",
                table: "DoanhNghieps");

            migrationBuilder.AddColumn<int>(
                name: "NhanVien",
                table: "DoanhNghieps",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DoanhNghieps",
                keyColumn: "Id",
                keyValue: 1,
                column: "NhanVien",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghieps_NhanVien",
                table: "DoanhNghieps",
                column: "NhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_DoanhNghieps_NhanViens_NhanVien",
                table: "DoanhNghieps",
                column: "NhanVien",
                principalTable: "NhanViens",
                principalColumn: "Id");
        }
    }
}
