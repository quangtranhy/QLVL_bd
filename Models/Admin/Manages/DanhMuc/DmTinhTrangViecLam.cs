using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTinhTrangViecLam
    {
        [Key]
        public int Id { get; set; }
        public string? MaTinhTrangViecLam { get; set; }
        public string? TenTinhTrangViecLam { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
