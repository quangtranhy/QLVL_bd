using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class AddDanhMuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DmChucVu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmDoiTuongUuTien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmDt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDoiTuong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmDoiTuongUuTien", x => x.Id);
                });


            

            migrationBuilder.CreateTable(
                name: "DmHinhThucLamViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmHinhThucLamViec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmLoaiHieuLucHdld",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmLhl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLhl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmLoaiHieuLucHdld", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmLoaiHinhHdkt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmLhkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLhkt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmLoaiHinhHdkt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmLoaiLaoDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmLld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmLoaiLaoDong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmMangHeTrinhDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDmmNtd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDmmNtd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmMangHeTrinhDo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmNganhNghe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmNganhNghe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmNganhSxkd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmSxkd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSxkd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmNganhSxkd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmNgheCongViec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmNgheCongViec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmNguyenNhanThatNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmNguyenNhanThatNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTinhTrangThamGiaHdkt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmTgkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTgkt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTinhTrangThamGiaHdkt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTinhTrangThamGiaHdktCt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDmTgktCt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTgktCt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTinhTrangThamGiaHdktCt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTinhTrangThamGiaHdktCt2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhom2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDmTgktCt2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTgktCt2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTinhTrangThamGiaHdktCt2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTrinhDoGdpt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmGdpt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenGdpt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTrinhDoGdpt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmTrinhDoKyThuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDmTdkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tentdkt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmTrinhDoKyThuat", x => x.Id);
                });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DmChucVu");

            migrationBuilder.DropTable(
                name: "DmDoiTuongUuTien");


            migrationBuilder.DropTable(
                name: "DmHinhThucLamViec");

            migrationBuilder.DropTable(
                name: "DmLoaiHieuLucHdld");

            migrationBuilder.DropTable(
                name: "DmLoaiHinhHdkt");

            migrationBuilder.DropTable(
                name: "DmLoaiLaoDong");

            migrationBuilder.DropTable(
                name: "DmMangHeTrinhDo");

            migrationBuilder.DropTable(
                name: "DmNganhNghe");

            migrationBuilder.DropTable(
                name: "DmNganhSxkd");

            migrationBuilder.DropTable(
                name: "DmNgheCongViec");

            migrationBuilder.DropTable(
                name: "DmNguyenNhanThatNghiep");

            migrationBuilder.DropTable(
                name: "DmTinhTrangThamGiaHdkt");

            migrationBuilder.DropTable(
                name: "DmTinhTrangThamGiaHdktCt");

            migrationBuilder.DropTable(
                name: "DmTinhTrangThamGiaHdktCt2");

            migrationBuilder.DropTable(
                name: "DmTrinhDoGdpt");

            migrationBuilder.DropTable(
                name: "DmTrinhDoKyThuat");
        }
    }
}
