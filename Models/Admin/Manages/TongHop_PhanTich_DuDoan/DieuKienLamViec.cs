using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan
{
    public class DieuKienLamViec
    {
        [Key]
        public int Id { get; set; }
        public string? MaDieuKien { get; set; }
        public string? TenDieuKien { get; set; }
        public string? CapDo { get; set; }
        public string? GhiChu { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
