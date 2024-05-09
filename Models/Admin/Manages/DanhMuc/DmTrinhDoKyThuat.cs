using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmTrinhDoKyThuat
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmTdkt { get; set; }
        [Required(ErrorMessage = "Tên trình độ kỹ thuật không được để trống!!!")]
        public string? Tentdkt { get; set; } 
        public string? Trangthai { get; set; } 
        public string? MoTa { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
