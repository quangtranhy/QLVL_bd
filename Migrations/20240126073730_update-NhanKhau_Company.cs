using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class updateNhanKhau_Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TinhTrangXacThuc",
                table: "NhanKhau",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TinhTrangXacThuc",
                table: "Company",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinhTrangXacThuc",
                table: "NhanKhau");

            migrationBuilder.DropColumn(
                name: "TinhTrangXacThuc",
                table: "Company");
        }
    }
}
