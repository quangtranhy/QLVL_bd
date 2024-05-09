using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class updateSystem1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
        name: "MaNhomChucNang",
        table: "DsNhomTaiKhoan",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "Stt",
        table: "DsNhomTaiKhoan",
        type: "int",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "TenNhomChucNang",
        table: "DsNhomTaiKhoan",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "GhiChu",
        table: "DsNhomTaiKhoan",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "DanhSachNhomChucNang",
        table: "DsNhomTaiKhoan",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "GhiChu",
        table: "DsNhomTaiKhoan_PhanQuyen",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "TenDangNhap",
        table: "DsTaiKhoan_PhanQuyen",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);

            migrationBuilder.AlterColumn<string>(
        name: "GhiChu",
        table: "DsTaiKhoan_PhanQuyen",
        type: "nvarchar(max)",
        nullable: true, // Đặt nullable thành false
        oldNullable: false);
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "Stt",
        table: "DsNhomTaiKhoan");

            migrationBuilder.DropColumn(
        name: "MaNhomChucNang",
        table: "DsNhomTaiKhoan");

            migrationBuilder.DropColumn(
        name: "TenNhomChucNang",
        table: "DsNhomTaiKhoan");

            migrationBuilder.DropColumn(
        name: "GhiChu",
        table: "DsNhomTaiKhoan");

            migrationBuilder.DropColumn(
        name: "DanhSachNhomChucNang",
        table: "DsNhomTaiKhoan");
            //
            migrationBuilder.DropColumn(
        name: "GhiChu",
        table: "DsNhomTaiKhoan_PhanQuyen");

            migrationBuilder.DropColumn(
        name: "GhiChu",
        table: "DsTaiKhoan_PhanQuyen");

            migrationBuilder.DropColumn(
        name: "TenDangNhap",
        table: "DsTaiKhoan_PhanQuyen");
        }
    }
}
