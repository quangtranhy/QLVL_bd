using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class addKeHoachThuThapThongTin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeHoachThuThapThongTin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLapKeHoach = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaKeHoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeHoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanCu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YeuCau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguyenTacThuThap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhoiLuongThongTinThuThap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungThuThap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SanPhamThuThap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeHoachThucHien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KinhPhiThucHien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToChucThucHien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LyDoTraLai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoKeHoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayKyKeHoach = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChucDanhKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoVaTenNguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDonViKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaDanh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachThuThapThongTin", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeHoachThuThapThongTin");
        }
    }
}
