using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Systems
{
    public class DmDonvi
    {
        [Key]
        public int Id { get; set; }
        public string? MaDonVi { get; set; }
        public string? Email { get; set; }
        public string? MaXa { get; set; }
        public string? MaHuyen { get; set; }
        public string? MaTinh { get; set; }
        public string? TenDv { get; set; }
        public string? DiaChi { get; set; }
        public string PhanLoaiTaiKhoan { get; set; } = null!;
        public string? CapHanhChinh { get; set; }
        public string? MaDvcq { get; set; }
        public string? DiaDanh { get; set; }
        public string? ChucVuKy { get; set; }
        public string? NguoiKy { get; set; }
        public string? TtLienHe { get; set; }
        public string? TenDvHienThi { get; set; }
        public string? MaDiaBan { get; set; }
        public string? MaDvBc { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public string? KhuVucHanhChinh { get; set; }
    }
}
