using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmLoaiHieuLucHdld
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmLhl { get; set; }
        [Required(ErrorMessage = "Tên loại hiệu lực hợp đồng lao động không được để trống!!!")]
        public string? TenLhl { get; set; }
        public string? Trangthai { get; set; }
        public string? Mota { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
