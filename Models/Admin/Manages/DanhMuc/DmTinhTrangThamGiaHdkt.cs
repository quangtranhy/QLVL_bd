using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTinhTrangThamGiaHdkt
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmTgkt { get; set; }
        [Required(ErrorMessage = "Tên tình trạng tham gia hoạt động kinh tế không được để trống!!!")]
        public string? TenTgkt { get; set; } 
        public string? Trangthai { get; set; }
        public string? MoTa { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public int CoutCt { get; set; }
    }
}
