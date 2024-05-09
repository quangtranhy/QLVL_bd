using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class KyBaoCao
    {
        [Key]
        public int Id { get; set; }
        public string? KyDieuTra { get; set; }
        public string? NoiDung { get; set; }
        public string? Madv_x { get; set; }
        public string? Cqtiepnhan_x { get; set; }
        public string? Trangthai_x { get; set; }
        public string? Thoidiem_x { get; set; }
        public string? Lydo_x { get; set; }
        public string? Madv_h { get; set; }
        public string? Cqtiepnhan_h { get; set; }
        public string? Trangthai_h { get; set; }
        public string? Thoidiem_h { get; set; }
        public string? Lydo_h { get; set; }
        public string? Madv_t { get; set; }
        public string? Trangthai_t { get; set; }
        public string? Thoidiem_t { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public string? Donvi { get; set; }
    }
}
