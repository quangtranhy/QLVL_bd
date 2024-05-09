using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class ViTriTuyenDung
    {
        [Key]
        public int Id { get; set; }
        public int IdTuyenDung { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public short? Soluong { get; set; }
        public string? MaNghe { get; set; }
        public string? CapBac { get; set; }
        public string? ChucVu { get; set; }
        public string? Tdgd { get; set; }
        public string? Tdcmkt { get; set; }
        public string? ChuyenNganh { get; set; }
        public string? TrinhDoNghe { get; set; }
        public short? BacNghe { get; set; }
        public string? NgoaiNgu1 { get; set; }
        public string? ChungChiNn1 { get; set; }
        public string? XeploaiNn1 { get; set; }
        public string? NgoaiNgu2 { get; set; }
        public string? ChungChiNn2 { get; set; }
        public string? XeploaiNn2 { get; set; }
        public string? LoaiThvp { get; set; }
        public string? TinHocKhac { get; set; }
        public string? LoaiThk { get; set; }
        public string? KyNangMem { get; set; }
        public string? YeuCauKn { get; set; }
        public string? DiaDiem { get; set; }
        public string? LoaiHopDong { get; set; }
        public string? YeuCautThem { get; set; }
        public string? HinhThuclv { get; set; }
        public string? MucDichLv { get; set; }
        public string? MucLuong { get; set; }
        public string? HoTroAn { get; set; }
        public string? PhucLoi { get; set; }
        public string? NoiLamViec { get; set; }
        public string? TrongLuongNang { get; set; }
        public string? DungVaDiLai { get; set; }
        public string? NgheNoi { get; set; }
        public string? ThiLuc { get; set; }
        public string? ThaoTacTay { get; set; }
        public string? DungTay { get; set; }
        public string? UuTien { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [DefaultValue("CXD")]
        public string? State { get; set; }
        [NotMapped]
        public string? TenNghe { get; set; }
    }
}
