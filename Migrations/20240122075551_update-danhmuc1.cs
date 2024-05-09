using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class updatedanhmuc1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DmDanToc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDanToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDanToc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmDanToc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmDoiTuongChinhSach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDoiTuongChinhSach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDoiTuongChinhSach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmDoiTuongChinhSach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmHinhThucDaoTao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHinhThucDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenHinhThucDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmHinhThucDaoTao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmHinhThucDoanhNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHinhThucDoanhNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenHinhThucDoanhNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmHinhThucDoanhNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmHinhThucThamGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHinhThucThamGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenHinhThucThamGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmHinhThucThamGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmKhuCongNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhuCongNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKhuCongNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmKhuCongNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmLoaiHinhDaoTao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiHinhDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLoaiHinhDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmLoaiHinhDaoTao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmLoaiViecLam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiViecLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLoaiViecLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmLoaiViecLam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmNghanhHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNghanhHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNghanhHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmNghanhHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmNgheDaoTao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNgheDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNgheDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmNgheDaoTao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmNguonViecLam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguonViecLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguonViecLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmNguonViecLam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmQuocGia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuocGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenQuocGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmQuocGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmThoiGianLamViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaThoiGianLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenThoiGianLamViec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmThoiGianLamViec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTinhTrangTanTat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTinhTrangTanTat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTinhTrangTanTat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTinhTrangTanTat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTinhTrangViecLam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTinhTrangViecLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTinhTrangViecLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTinhTrangViecLam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTonGiao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTonGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTonGiao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTonGiao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTrangThaiViecLam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTrangThaiViecLam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTrangThaiViecLam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTrangThaiViecLam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTrinhDoHocVan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTrinhDoHocVan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTrinhDoHocVan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTrinhDoHocVan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTrinhDoNgoaiNgu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTrinhDoNgoaiNgu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTrinhDoNgoaiNgu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTrinhDoNgoaiNgu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTrinhDoTinHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTrinhDoTinHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenTrinhDoTinHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTrinhDoTinHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmXuatKhauLaoDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaXuatKhauLaoDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenXuatKhauLaoDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmXuatKhauLaoDong", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DmDanToc");

            migrationBuilder.DropTable(
                name: "DmDoiTuongChinhSach");

            migrationBuilder.DropTable(
                name: "DmHinhThucDaoTao");

            migrationBuilder.DropTable(
                name: "DmHinhThucDoanhNghiep");

            migrationBuilder.DropTable(
                name: "DmHinhThucThamGia");

            migrationBuilder.DropTable(
                name: "DmKhuCongNghiep");

            migrationBuilder.DropTable(
                name: "DmLoaiHinhDaoTao");

            migrationBuilder.DropTable(
                name: "DmLoaiViecLam");

            migrationBuilder.DropTable(
                name: "DmNghanhHoc");

            migrationBuilder.DropTable(
                name: "DmNgheDaoTao");

            migrationBuilder.DropTable(
                name: "DmNguonViecLam");

            migrationBuilder.DropTable(
                name: "DmQuocGia");

            migrationBuilder.DropTable(
                name: "DmThoiGianLamViec");

            migrationBuilder.DropTable(
                name: "DmTinhTrangTanTat");

            migrationBuilder.DropTable(
                name: "DmTinhTrangViecLam");

            migrationBuilder.DropTable(
                name: "DmTonGiao");

            migrationBuilder.DropTable(
                name: "DmTrangThaiViecLam");

            migrationBuilder.DropTable(
                name: "DmTrinhDoHocVan");

            migrationBuilder.DropTable(
                name: "DmTrinhDoNgoaiNgu");

            migrationBuilder.DropTable(
                name: "DmTrinhDoTinHoc");

            migrationBuilder.DropTable(
                name: "DmXuatKhauLaoDong");
        }
    }
}
