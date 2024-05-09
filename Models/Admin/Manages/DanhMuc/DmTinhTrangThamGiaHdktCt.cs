using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTinhTrangThamGiaHdktCt
    {
        [Key]
        public int Id { get; set; }
        public string? MaNhom { get; set; }
        public string? MaDmTgktCt { get; set; }
        public string? TenTgktCt { get; set; } 
        public string? Trangthai { get; set; } 
        public string? MoTa { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public int CoutCt { get; set; }
    }
}
