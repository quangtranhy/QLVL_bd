using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmHinhThucDaoTao
    {
        [Key]
        public int Id { get; set; }
        public string? MaHinhThucDaoTao { get; set; }
        public string? TenHinhThucDaoTao { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
