using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmMangHeTrinhDo
    {
        [Key]
        public int Id { get; set; }
        public string? MaNghe { get; set; }
        public string? MaDmmNtd { get; set; }
        [Required(ErrorMessage = "Tên mã nghề trình độ không được để trống!!!")]
        public string? TenDmmNtd { get; set; }
        public string? Trangthai { get; set; }
        public string? MoTa { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
