using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTinhTrangThamGiaHdktCt2
    {
        [Key]
        public int Id { get; set; }
        public string? MaNhom2 { get; set; }
        public string? MaDmTgktCt2 { get; set; }
        public string? TenTgktCt2 { get; set; }
        public string? Trangthai { get; set; } 
        public string? MoTa { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
