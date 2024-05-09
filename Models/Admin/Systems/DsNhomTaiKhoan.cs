using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Systems
{
    public class DsNhomTaiKhoan
    {
        public int Id { get; set; }
        public int Stt { get; set; }
        [Required(ErrorMessage = "Mã nhóm chức năng không được để trống")]
        public string? MaNhomChucNang { get; set; }
        [Required(ErrorMessage = "Tên nhóm không được để trống")]
        public string? TenNhomChucNang { get; set; } = null!;
        public string? GhiChu { get; set; }
        [NotMapped]
        public string? DanhSachNhomChucNang { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
