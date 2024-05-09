using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class KeHoachThuThapThongTin
    {
        [Key]
        public int Id { get; set; }
        public DateTime NgayLapKeHoach { get; set; }
        public string? MaKeHoach { get; set; }
        public string? KeHoach { get; set; }
        public string? CanCu { get; set; }
        public string? MucDich { get; set; }
        public string? YeuCau { get; set; }
        public string? NguyenTacThuThap { get; set; }
        public string? KhoiLuongThongTinThuThap { get; set; }
        public string? NoiDungThuThap { get; set; }
        public string? SanPhamThuThap { get; set; }
        public string? KeHoachThucHien { get; set; }
        public string? KinhPhiThucHien { get; set; }
        public string? ToChucThucHien { get; set; }

        public string? Status { get; set; }
        public string? LyDoTraLai { get; set; }
        public string? SoKeHoach { get; set; }
        public DateTime NgayKyKeHoach { get; set; }
        public string? ChucDanhKy { get; set; }
        public string? HoVaTenNguoiKy { get; set; }
        public string? TenDonViKy { get; set; }
        public string? DiaDanh { get; set; }
    }
}
