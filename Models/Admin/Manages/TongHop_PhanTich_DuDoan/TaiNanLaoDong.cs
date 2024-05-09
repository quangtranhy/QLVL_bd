using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan
{
    public class TaiNanLaoDong
    {
        [Key]
        public long Id { get; set; }
        public string? IdNguoiLaoDong { get; set; }
        public string? Ccnd { get; set; }
        public int? MaRuiro { get; set; }
        public string? Mota { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped] public string? Stt { get; set; }
    }
}
