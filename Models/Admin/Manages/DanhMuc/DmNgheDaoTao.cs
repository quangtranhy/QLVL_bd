using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmNgheDaoTao
    {
        [Key]
        public int Id { get; set; }
        public string? MaNgheDaoTao { get; set; }
        public string? TenNgheDaoTao { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
