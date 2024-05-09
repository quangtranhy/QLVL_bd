using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmKhuCongNghiep
    {
        [Key]
        public int Id { get; set; }
        public string? MaKhuCongNghiep { get; set; }
        public string? TenKhuCongNghiep { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
