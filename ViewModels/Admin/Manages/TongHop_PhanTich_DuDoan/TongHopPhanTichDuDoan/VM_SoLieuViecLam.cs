using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan
{
    public class VM_SoLieuViecLam
    {
        [Key]
       
        public string? Name { get; set; }
        public string? Xa { get; set; }
        public string? Huyen { get; set; }
        public string? Parent { get; set; }
        public string? MaQuocGia { get; set; }
        public string? CapDo { get; set; }
        [NotMapped]
        public int Stt { get; set; }
        [NotMapped]
        public int Count { get; set; }
        [NotMapped]
        public int? Soluong { get; set; }
    }
}
