using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class NhanKhau
    {
        [Key]
        public int Id { get; set; }
        public int? DanhSach_id { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public string? NgaySinh { get; set; }
        public string? Cccd { get; set; }
        public string? Bhxh { get; set; }
        public string? ThuongTru { get; set; }
        public string? DiaChi { get; set; }
        public string? UuTien { get; set; }
        public string? DanToc { get; set; }
        public string? TrinhDoGiaoDuc { get; set; }
        public string? ChuyenMonKyThuat { get; set; }
        public string? ChuyenNganh { get; set; }
        public string? TinhTrangHdkt { get; set; }
        public string? NguoiCoVieclam { get; set; }
        public string? CongViecCuThe { get; set; }
        public string? ThamGiaBhxh { get; set; }
        public string? Hdld { get; set; }
        public string? NoiLamViec { get; set; }
        public string? LoaiHinhNoiLamViec { get; set; }
        public string? DiaChiNoiLamViec { get; set; }
        public string? ThatNghiep { get; set; }
        public string? ThoiGianThatNghiep { get; set; }
        public string? KhongThamGiaHdkt { get; set; }
        public string? Ho { get; set; }
        public string? Mqh { get; set; }
        public string? MaLoi { get; set; }
        public string? MaLoaiLoi { get; set; }
        public string? MaDonVi { get; set; }
        public string? KyDieuTra { get; set; }
        public int? SoLuongTrung { get; set; }
        public int? LoaiBienDong { get; set; }
        public string? RuongBienDong { get; set; }
        public int? DoiTuongTimViecLam { get; set; }
        public int? ViecLamMongMuon { get; set; }
        public string? NganhNgheMongMuon { get; set; }
        public string? NganhNgheMuonHoc { get; set; }
        public string? TrinhDoChuyenMonMuonHoc { get; set; }
        public string? Sdt { get; set; }
        public int? KhuVuc { get; set; }
        public string? ThiTruongLamViec { get; set; }
        public string? LyDo { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public string? Tentdkt { get; set; }
        [NotMapped]
        public short? IdTuyenDung { get; set; }
        public bool TinhTrangXacThuc { get; set; }
    }
}
