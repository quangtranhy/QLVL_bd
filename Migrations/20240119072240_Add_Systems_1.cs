using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class Add_Systems_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucNang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenCn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<int>(type: "int", nullable: true),
                    CapDo = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaChucNang_Goc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucNang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmDonvi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaXa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanLoaiTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapHanhChinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDvcq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVuKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TtLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDvHienThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDiaBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDvBc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmDonvi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmHanhChinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Public = table.Column<int>(type: "int", nullable: true),
                    Kv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaQuocGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDvql = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaDb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapDo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmHanhChinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "DsNhomTaiKhoan",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Stt = table.Column<int>(type: "int", nullable: true),
                   MaNhomChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   TenNhomChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   DanhSachNhomChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  
                   Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_DsNhomTaiKhoan", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "DsNhomTaiKhoan_PhanQuyen",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   MaNhomChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   MaChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   PhanQuyen = table.Column<bool>(type: "bit", nullable: false),
                   DanhSach = table.Column<bool>(type: "bit", nullable: false),
                   ThayDoi = table.Column<bool>(type: "bit", nullable: false),
                   HoanThanh = table.Column<bool>(type: "bit", nullable: false),
                   GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                   DeleteRecordTrash = table.Column<bool>(type: "bit", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_DsNhomTaiKhoan_PhanQuyen", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "DsTaiKhoan_PhanQuyen",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   MaChucNang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   PhanQuyen = table.Column<bool>(type: "bit", nullable: false),
                   DanhSach = table.Column<bool>(type: "bit", nullable: false),
                   ThayDoi = table.Column<bool>(type: "bit", nullable: false),
                   HoanThanh = table.Column<bool>(type: "bit", nullable: false),
                   GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_DsTaiKhoan_PhanQuyen", x => x.Id);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChucNang");
            migrationBuilder.DropTable(
                name: "DmDonvi");
            migrationBuilder.DropTable(
                name: "DmHanhChinh");
            migrationBuilder.DropTable(
                name: "DsNhomTaiKhoan");
            migrationBuilder.DropTable(
                name: "DsNhomTaiKhoan_PhanQuyen");
            migrationBuilder.DropTable(
                name: "DsTaiKhoan_PhanQuyen");
        }
    }
}
