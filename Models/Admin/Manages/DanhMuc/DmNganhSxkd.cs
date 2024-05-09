using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.DanhMuc
{
    public class DmNganhSxkd
    {
        [Key]
        public int Id { get; set; }
        public string? MaDmSxkd { get; set; }
        [Required(ErrorMessage = "Tên ngành sản xuất kinh doanh không được để trống!!!")]
        public string? TenSxkd { get; set; }
        public string? Trangthai { get; set; }
        public string? MoTa { get; set; }
        public int Stt { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
