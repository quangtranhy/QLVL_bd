using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmNghanhHoc
    {
        [Key]
        public int Id { get; set; }
        public string? MaNghanhHoc { get; set; }
        public string? TenNghanhHoc { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
