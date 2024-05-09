using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmHinhThucThamGia
    {
        [Key]
        public int Id { get; set; }
        public string? MaHinhThucThamGia { get; set; }
        public string? TenHinhThucThamGia { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
