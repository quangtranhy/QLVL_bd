using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTinhTrangTanTat
    {
        [Key]
        public int Id { get; set; }
        public string? MaTinhTrangTanTat { get; set; }
        public string? TenTinhTrangTanTat { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
