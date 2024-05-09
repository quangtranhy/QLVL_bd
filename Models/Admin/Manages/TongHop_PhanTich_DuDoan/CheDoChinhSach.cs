using System.ComponentModel.DataAnnotations;

namespace QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan
{
    public class CheDoChinhSach
    {
        [Key]
        public int Id { get; set; }
        public string? MaBhxh { get; set; }
        //che do do nld dong
        public double? OmDau_Nld { get; set; }
        public double? ThaiSan_Nld { get; set; }
        public double? Tnld_Nld { get; set; }
        public double? HuuTri_Nld { get; set; }
        public double? TuTuat_Nld { get; set; }
        //che do do nsdld dong
        public double? OmDau_Nsdld { get; set; }
        public double? ThaiSan_Nsdld { get; set; }
        public double? Tnld_Nsdld { get; set; }
        public double? HuuTri_Nsdld { get; set; }
        public double? TuTuat_Nsdld { get; set; }
        public double? Bhtn { get; set; }
        public double? Bhxh { get; set; }
        public double? Bhyt { get; set; }
        public string? SoTienDaDong { get; set; }
        public string? SoTienDaHuong { get; set; }
        public string? GhiChu { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
