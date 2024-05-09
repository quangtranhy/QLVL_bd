using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class NguoiLaoDong
    {
        [Key]
        public int Id { get; set; }
        public string? HoTen { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? Ccnd { get; set; }
        public string? DanToc { get; set; }
        public string? Nation { get; set; }
        public string? Tinh { get; set; }
        public string? Huyen { get; set; }
        public string? Xa { get; set; }
        public string? Address { get; set; }
        public string? SoBaoHiem { get; set; }
        public string? TrinhDoGiaoDuc { get; set; }
        public string? TrinhDoCmkt { get; set; }
        public string? NgheNghiep { get; set; }
        public string? LinhVucDaoTao { get; set; }
        public string? LoaiHdld { get; set; }
        public DateTime BdHopDong { get; set; }
        public DateTime KtHopDong { get; set; }
        public string? Luong { get; set; }
        public string? PcChucVu { get; set; }
        public string? PcThamNien { get; set; }
        public string? PcThamNienNghe { get; set; }
        public string? PcLuong { get; set; }
        public string? PcBoSung { get; set; }
        public DateTime BdDocHai { get; set; }
        public DateTime KtDocHai { get; set; }
        public string? ViTri { get; set; }
        public string? ChucVu { get; set; }
        public DateTime BdBhxh { get; set; }
        public DateTime KtBhxh { get; set; }
        public string? LuongBhxh { get; set; }
        public string? GhiChu { get; set; }
        //public string? nhankhau_id { get; set; }
        //public string? madv { get; set; }
        //public string? kydieutra { get; set; }
        //public string? maloi { get; set; }
        public int Company { get; set; }
        public short State { get; set; }
        public short? FromTtdvvl { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [NotMapped]
        public string? TenDn { get; set; }
        //sẽ lấy theo mã quốc gia ánh xạ vào đọc ra tên,nếu null=>trong nước
        public string? Abroad { get; set; }
        //public CheDoChinhSach? CheDoChinhSach { get; set; }
    }
}
