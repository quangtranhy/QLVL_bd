using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmNguonViecLam
    {
        [Key]
        public int Id { get; set; }
        public string? MaNguonViecLam { get; set; }
        public string? TenNguonViecLam { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
