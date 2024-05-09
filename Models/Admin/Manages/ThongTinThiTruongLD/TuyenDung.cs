using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class TuyenDung
    {
        [Key]
        public int Id { get; set; }
        public string? NoiDung { get; set; }
        public string? Type { get; set; }
        public string? Contact { get; set; }
        public string? PhoneTd { get; set; }
        public string? EmailTd { get; set; }
        public string? ChucvuTd { get; set; }
        public string? ContactType { get; set; }
        public string? YeuCau { get; set; }
        public short? State { get; set; }
        public short? DaTuyen { get; set; }
        public short? DaTuyenTutt { get; set; }
        public int? User { get; set; }
        public DateTime ThoiHan { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public string? TenCongTy { get; set; }
    }
}
