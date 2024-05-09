using System.ComponentModel.DataAnnotations.Schema;

namespace QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT
{
    public class VM_TuyenDung
    {
        public int Id { get; set; }
        public string? NoiDung { get; set; }
        public string? Type { get; set; }
        public string? Contact { get; set; }
        public string? Phonetd { get; set; }
        public string? Emailtd { get; set; }
        public string? ChucVuTd { get; set; }
        public string? ContactType { get; set; }
        public string? YeuCau { get; set; }
        public short? State { get; set; }
        public short? DaTuyen { get; set; }
        public short? DaTuyenTutt { get; set; }
        public int? User { get; set; }
        public DateTime ThoiHan { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        //public List<vitrituyendung> vitrituyendung { get; set; }
        [NotMapped]
        public string? Name { get; set; }
        [NotMapped]
        public int? SoLuong { get; set; }
        [NotMapped]
        public string? DoanhNghiep { get; set; }
        [NotMapped]
        public string? ViTri { get; set; }
        [NotMapped]
        public int? IdTuyenDung { get; set; }
    }
}
