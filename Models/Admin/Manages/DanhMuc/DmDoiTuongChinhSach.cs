using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmDoiTuongChinhSach
    {
        [Key]
        public int Id { get; set; }
        public string? MaDoiTuongChinhSach { get; set; }
        public string? TenDoiTuongChinhSach { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
