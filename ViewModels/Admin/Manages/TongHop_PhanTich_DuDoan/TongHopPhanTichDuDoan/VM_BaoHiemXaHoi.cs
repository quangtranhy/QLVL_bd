using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan
{
    public class VM_BaoHiemXaHoi
    {
        //1:tu nguyen   2:bat buoc  3:k0 tham gia
        public string? ThamGiaBaoHiem { get; set; }
        public string? MaBhxh { get; set; }
    }
}
