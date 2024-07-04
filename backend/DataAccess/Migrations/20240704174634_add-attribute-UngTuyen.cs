using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addattributeUngTuyen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UngTuyens_UngViens_UngVienId",
                table: "UngTuyens");

            migrationBuilder.AlterColumn<int>(
                name: "UngVienId",
                table: "UngTuyens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UngTuyens_UngViens_UngVienId",
                table: "UngTuyens",
                column: "UngVienId",
                principalTable: "UngViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UngTuyens_UngViens_UngVienId",
                table: "UngTuyens");

            migrationBuilder.AlterColumn<int>(
                name: "UngVienId",
                table: "UngTuyens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UngTuyens_UngViens_UngVienId",
                table: "UngTuyens",
                column: "UngVienId",
                principalTable: "UngViens",
                principalColumn: "Id");
        }
    }
}
