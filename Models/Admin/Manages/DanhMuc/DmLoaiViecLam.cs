using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmLoaiViecLam
    {
        [Key]
        public int Id { get; set; }
        public string? MaLoaiViecLam { get; set; }
        public string? TenLoaiViecLam { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
