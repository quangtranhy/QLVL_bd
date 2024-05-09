using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmDoiTuongUuTien
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmDt { get; set; }
        [Required(ErrorMessage = "Tên đối tượng không được để trống!!!")]
        public string? TenDoiTuong { get; set; }
        public string? Trangthai { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
