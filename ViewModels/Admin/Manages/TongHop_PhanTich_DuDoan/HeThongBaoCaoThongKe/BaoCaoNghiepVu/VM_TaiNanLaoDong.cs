using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu
{
    public class VM_TaiNanLaoDong
    {
        public string? IdNguoiLaoDong { get; set; }
        public int? MaRuiro { get; set; }
        public string? HoTen { get; set; }
        public string? TenRuiro { get; set; }
        public string? Mota { get; set; }
        [NotMapped] public string? Stt { get; set; }
    }
}
