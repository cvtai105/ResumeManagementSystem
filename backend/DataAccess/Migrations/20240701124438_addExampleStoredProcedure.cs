using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addExampleStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //Them procedure tại đây
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetNhanVienInfo
                    @Email NVARCHAR(255)
                AS
                BEGIN
                    SELECT TenNhanVien AS FullName, Email, MatKhau AS Password
                    FROM NhanViens
                    WHERE Email = @Email
                END;
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
