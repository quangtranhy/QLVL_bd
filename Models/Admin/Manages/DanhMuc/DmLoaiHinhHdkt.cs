using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmLoaiHinhHdkt
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmLhkt { get; set; }
        [Required(ErrorMessage = "Tên loại hoạt động kinh tế không được để trống!!!")]
        public string? TenLhkt { get; set; }
        public string? Trangthai { get; set; }
        public string? MoTa { get; set; }
        public int Stt { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
