using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmLoaiLaoDong
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmLld { get; set; }
        [Required(ErrorMessage = "Tên loại lao động không được để trống!!!")]
        public string? TenLld { get; set; }
        public string? Trangthai { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
