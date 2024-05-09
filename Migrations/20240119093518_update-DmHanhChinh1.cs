using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class updateDmHanhChinh1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "MaDb",
        table: "DmHanhChinh",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "CapDo",
        table: "DmHanhChinh",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "MaDb",
        table: "DmHanhChinh");

            migrationBuilder.DropColumn(
        name: "CapDo",
        table: "DmHanhChinh");
        }
    }
}
