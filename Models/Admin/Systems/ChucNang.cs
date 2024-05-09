using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Systems
{
    public class ChucNang
    {
        [Key]
        public int Id { get; set; }
        public string? MaSo { get; set; }
        public string? TenCn { get; set; }
        public int? Parent { get; set; }
        public int? CapDo { get; set; }
        public string? TrangThai { get; set; }
        public string? MaChucNang_Goc { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public string? Stt { get; set; }
    }
}
