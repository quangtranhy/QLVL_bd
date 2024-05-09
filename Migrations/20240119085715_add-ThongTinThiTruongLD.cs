using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLViecLam.Migrations
{
    /// <inheritdoc />
    public partial class addThongTinThiTruongLD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaSoDn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dkkd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhuVuc = table.Column<int>(type: "int", nullable: false),
                    KhuCn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Public = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<int>(type: "int", nullable: false),
                    NganhNghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remember_Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaDv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyMo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sld = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DsThatNghiep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyDieuTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguyenNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoCmkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheCongViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsThatNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KyBaoCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyDieuTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Madv_x = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cqtiepnhan_x = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthai_x = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thoidiem_x = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lydo_x = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Madv_h = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cqtiepnhan_h = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthai_h = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thoidiem_h = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lydo_h = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Madv_t = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthai_t = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thoidiem_t = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyBaoCao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiLaoDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ccnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanToc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Huyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoBaoHiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoGiaoDuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoCmkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinhVucDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHdld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BdHopDong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtHopDong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Luong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcThamNien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcThamNienNghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcBoSung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BdDocHai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtDocHai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BdBhxh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtBhxh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LuongBhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<short>(type: "smallint", nullable: false),
                    FromTtdvvl = table.Column<short>(type: "smallint", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiLaoDong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanKhau",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanhSach_id = table.Column<int>(type: "int", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cccd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UuTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanToc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoGiaoDuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuyenMonKyThuat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrangHdkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCoVieclam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongViecCuThe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThamGiaBhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hdld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHinhNoiLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiNoiLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThatNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianThatNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhongThamGiaHdkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mqh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiLoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyDieuTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongTrung = table.Column<int>(type: "int", nullable: true),
                    LoaiBienDong = table.Column<int>(type: "int", nullable: true),
                    RuongBienDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoiTuongTimViecLam = table.Column<int>(type: "int", nullable: true),
                    ViecLamMongMuon = table.Column<int>(type: "int", nullable: true),
                    NganhNgheMongMuon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NganhNgheMuonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoChuyenMonMuonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhuVuc = table.Column<int>(type: "int", nullable: true),
                    ThiTruongLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanKhau", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TongHopCungLaoDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyDieuTra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LdTren15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LdcoViecLam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LdThatNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LdKhongThamGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NongThon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capdo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrongNuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NuocNgoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HocNghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopCungLaoDong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TuyenDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneTd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucvuTd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YeuCau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<short>(type: "smallint", nullable: true),
                    DaTuyen = table.Column<short>(type: "smallint", nullable: true),
                    DaTuyenTutt = table.Column<short>(type: "smallint", nullable: true),
                    User = table.Column<int>(type: "int", nullable: true),
                    ThoiHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViTriTuyenDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTuyenDung = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soluong = table.Column<short>(type: "smallint", nullable: true),
                    MaNghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapBac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tdgd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tdcmkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrinhDoNghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BacNghe = table.Column<short>(type: "smallint", nullable: true),
                    NgoaiNgu1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChungChiNn1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XeploaiNn1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgoaiNgu2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChungChiNn2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XeploaiNn2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThvp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinHocKhac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyNangMem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YeuCauKn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiHopDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YeuCautThem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhThuclv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucDichLv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MucLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTroAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhucLoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrongLuongNang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungVaDiLai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheNoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThiLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThaoTacTay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DungTay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UuTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTriTuyenDung", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "DsThatNghiep");

            migrationBuilder.DropTable(
                name: "KyBaoCao");

            migrationBuilder.DropTable(
                name: "NguoiLaoDong");

            migrationBuilder.DropTable(
                name: "NhanKhau");

            migrationBuilder.DropTable(
                name: "TongHopCungLaoDong");

            migrationBuilder.DropTable(
                name: "TuyenDung");

            migrationBuilder.DropTable(
                name: "ViTriTuyenDung");
        }
    }
}
