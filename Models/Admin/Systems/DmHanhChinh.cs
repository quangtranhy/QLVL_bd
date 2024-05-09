using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Systems
{
    public class DmHanhChinh
    {
        [Key]
        public int Id { get; set; }
        public int Public { get; set; }
        public string? Kv { get; set; }
        [Required(ErrorMessage = "Tên khu vực hành chính không được để trống ")]
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public string? Level { get; set; }
        public string? Parent { get; set; }
        public string? MaQuocGia { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? MaDvql { get; set; }
        public string? MaDb { get; set; }
        public string? CapDo { get; set; }
        [NotMapped]
        public int Stt { get; set; }
        [NotMapped]
        public int Count { get; set; }
        [NotMapped]
        public int? Luongduoi5 { get; set; }
        [NotMapped]
        public int? Luong5to10 { get; set; }
        [NotMapped]
        public int? Luong10to20 { get; set; }
        [NotMapped]
        public int? Luong20to50 { get; set; }
        [NotMapped]
        public int? Luongtren50 { get; set; }
    }
}
