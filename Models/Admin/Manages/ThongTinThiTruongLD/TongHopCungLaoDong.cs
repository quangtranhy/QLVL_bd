using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD
{
    public class TongHopCungLaoDong
    {
        [Key]
        public int Id { get; set; }
        public string? KyDieuTra { get; set; }
        public string? MaDonVi { get; set; }
        public string? TenDv { get; set; }
        public string? LdTren15 { get; set; }
        public string? LdcoViecLam { get; set; }
        public string? LdThatNghiep { get; set; }
        public string? LdKhongThamGia { get; set; }
        public string? ThanhThi { get; set; }
        public string? NongThon { get; set; }
        public string? Nam { get; set; }
        public string? Nu { get; set; }
        public string? Capdo { get; set; }
        public string? TrongNuoc { get; set; }
        public string? NuocNgoai { get; set; }
        public string? HocNghe { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }
    }
}
