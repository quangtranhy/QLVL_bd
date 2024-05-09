using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmChucVu
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên chức vụ không được để trống !!!")]
        public string? TenCv { get; set; }
        public string? MoTa { get; set; }
        public string? Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
