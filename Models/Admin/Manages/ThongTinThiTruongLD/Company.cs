using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MaSoDn { get; set; }
        public string? Dkkd { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Tinh { get; set; }
        public string? Huyen { get; set; }
        public string? Xa { get; set; }
        public int KhuVuc { get; set; }
        public string? KhuCn { get; set; }
        public string? LoaiHinh { get; set; }
        public int Public { get; set; }
        public string? Image { get; set; }
        public int User { get; set; }
        public string? NganhNghe { get; set; }
        public string? Remember_Token { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? MaDv { get; set; }
        public string? QuyMo { get; set; }
        
        public int Sld { get; set; }
        public bool TinhTrangXacThuc { get; set; }
    }
}
