using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Systems
{
    public class DsTaiKhoan_PhanQuyen
    {
        [Key]
        public int Id { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MaChucNang { get; set; }
        public bool PhanQuyen { get; set; }
        public bool DanhSach { get; set; }
        public bool ThayDoi { get; set; }
        public bool HoanThanh { get; set; }
        public string? GhiChu { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
