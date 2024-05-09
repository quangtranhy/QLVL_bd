using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan
{
    public class BanTin
    {
        [Key]
        public int Id { get; set; }
        public string? TieuDe { get; set; }
        public string? TrangThai { get; set; }
        public DateTime? ThoiDiem { get; set; }
        public string? MoTa { get; set; }
        public string? NoiDung { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
