using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmNganhNghe
    {
        [Key]
        public int Id { get; set; }
        public string? MaDm { get; set; }
        public string? TenDm { get; set; }
        public int? Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        [NotMapped]
        public int? Count { get; set; }
    }
}
