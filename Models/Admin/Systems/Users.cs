using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.Models.Admin.Systems
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Thông tin không được để trống")]
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Thông tin không được để trống")]
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public int? Level { get; set; }
        public string? Remember_Token { get; set; }
        public int? Public { get; set; }
        public string? Image { get; set; }
        public int Category { get; set; }
        public string? MaDonVi { get; set; }
        public string? MaXa { get; set; }
        public string? MaHuyen { get; set; }
        public string? MaTinh { get; set; }
        public string? PhanLoaiTk { get; set; }
        public string? Status { get; set; }
        public string? Sadmin { get; set; }
        public string? MaNhomChucNang { get; set; }
        public bool NhapLieu { get; set; }
        public bool TongHop { get; set; }
        public bool HeThong { get; set; }
        public bool ChucNangKhac { get; set; }
        public string? CapDo { get; set; }
        public string? MaDvBc { get; set; }

        [NotMapped]
        public string? DonViQuanLy { get; set; }
        [NotMapped]
        public string? LoaiTaiKhoan { get; set; }

        //add
        public string? Content { get; set; }
        public string? Menu { get; set; }
        public string? Theme { get; set; }
        public int CountLogin { get; set; }
        public string? Group { get; set; }

        public string? TenDonViChuQuanBc { get; set; }
        public string? TenDonViBc { get; set; }
        public string? DiaDanhBc { get; set; }
        public string? ChucDanhNguoiKyBc { get; set; }
        public string? HoTenNguoiKyBc { get; set; }
        //

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}


