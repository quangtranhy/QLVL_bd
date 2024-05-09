using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class update_CheDoChinhSach : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapDo",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "TienLuong",
                table: "CheDoChinhSach");

            migrationBuilder.RenameColumn(
                name: "TenCheDo",
                table: "CheDoChinhSach",
                newName: "SoTienDaHuong");

            migrationBuilder.RenameColumn(
                name: "Nam",
                table: "CheDoChinhSach",
                newName: "SoTienDaDong");

            migrationBuilder.RenameColumn(
                name: "MaCheDo",
                table: "CheDoChinhSach",
                newName: "MaBhxh");

            migrationBuilder.AlterColumn<double>(
                name: "Bhxh",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Bhtn",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HuuTri_Nld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HuuTri_Nsdld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OmDau_Nld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OmDau_Nsdld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ThaiSan_Nld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ThaiSan_Nsdld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Tnld_Nld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Tnld_Nsdld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TuTuat_Nld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TuTuat_Nsdld",
                table: "CheDoChinhSach",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bhtn",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "HuuTri_Nld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "HuuTri_Nsdld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "OmDau_Nld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "OmDau_Nsdld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "ThaiSan_Nld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "ThaiSan_Nsdld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "Tnld_Nld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "Tnld_Nsdld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "TuTuat_Nld",
                table: "CheDoChinhSach");

            migrationBuilder.DropColumn(
                name: "TuTuat_Nsdld",
                table: "CheDoChinhSach");

            migrationBuilder.RenameColumn(
                name: "SoTienDaHuong",
                table: "CheDoChinhSach",
                newName: "TenCheDo");

            migrationBuilder.RenameColumn(
                name: "SoTienDaDong",
                table: "CheDoChinhSach",
                newName: "Nam");

            migrationBuilder.RenameColumn(
                name: "MaBhxh",
                table: "CheDoChinhSach",
                newName: "MaCheDo");

            migrationBuilder.AlterColumn<string>(
                name: "Bhxh",
                table: "CheDoChinhSach",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapDo",
                table: "CheDoChinhSach",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TienLuong",
                table: "CheDoChinhSach",
                type: "int",
                nullable: true);
        }
    }
}
