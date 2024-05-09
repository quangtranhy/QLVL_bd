using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class DsThatNghiep
    {
        [Key]
        public int Id { get; set; }
        public string? KyDieuTra { get; set; }
        public string? HoTen { get; set; }
        public string? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? Cccd { get; set; }
        public string? Bhxh { get; set; }
        public string? DiaChi { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? NguyenNhan { get; set; }
        public string? TrinhDoCmkt { get; set; }
        public string? NgheNghiep { get; set; }
        public string? NgheCongViec { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
