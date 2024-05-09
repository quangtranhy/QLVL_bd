using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class addTongHop_PhanTich_DuDoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheDoChinhSach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCheDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenCheDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bhyt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienLuong = table.Column<int>(type: "int", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheDoChinhSach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DieuKienLamViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDieuKien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDieuKien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DieuKienLamViec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhuongTienLamViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhuongTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenPhuongTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongTienLamViec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuiRoLamViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaRuiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenRuiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuiRoLamViec", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheDoChinhSach");

            migrationBuilder.DropTable(
                name: "DieuKienLamViec");

            migrationBuilder.DropTable(
                name: "PhuongTienLamViec");

            migrationBuilder.DropTable(
                name: "RuiRoLamViec");
        }
    }
}
