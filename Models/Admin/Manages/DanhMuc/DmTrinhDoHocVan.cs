using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTrinhDoHocVan
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? MaTrinhDoHocVan { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string? TenTrinhDoHocVan { get; set; }
        public string? MoTa { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
