using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmQuocGia
    {
        [Key]
        public int Id { get; set; }
        public string? MaQuocGia { get; set; }
        public string? TenQuocGia { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
