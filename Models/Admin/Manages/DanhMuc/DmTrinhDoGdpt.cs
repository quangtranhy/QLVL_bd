using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTrinhDoGdpt
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmGdpt { get; set; }
        [Required(ErrorMessage = "Tên trình độ giáo dục phổ thông không được để trống!!!")]
        public string? TenGdpt { get; set; }
        public string? Trangthai { get; set; }
        public string? Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
