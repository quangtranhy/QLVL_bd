using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.ViewModels;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.HeThongTruyVanTT;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.TruyVanThongTinLaoDong
{
    public class TruyVanCungCauLDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TruyVanCungCauLDController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("TruyVanCungCauLD/DanhSachTuyenDung")]
        [HttpGet]
        public IActionResult DanhSachTuyenDung(short TrangThai, int DoanhNghiep = 0)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.TuyenDung.AsEnumerable();
                if (DoanhNghiep != 0)
                {
                    model = model.Where(x=>x.User== DoanhNghiep);
                }                
                foreach (var item in model) 
                {
                    item.TenCongTy = _db.Company.FirstOrDefault(x=>x.Id==item.User)!.Name;
                }
                ViewData["Cout"] = model.Count();
                ViewData["TrangThai"] = TrangThai;
                ViewData["DsDoanhNghiep"] = _db.Company;
                ViewData["DoanhNghiep"] = DoanhNghiep;

                ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cungcau";
                return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CungCauLaoDong/DanhSachTuyenDung.cshtml", model);
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }
        [Route("TruyVanCungCauLD/DsViTriTuyenDung")]
        [HttpGet]
        public IActionResult DsViTriTuyenDung(short Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.ViTriTuyenDung.Where(x => x.IdTuyenDung == Id);
                    var tuyendung = _db.TuyenDung.FirstOrDefault(x => x.Id == Id);
                    foreach (var item in model)
                    {
                        var nghe = _db.DmNganhNghe.FirstOrDefault(x => x.MaDm == item.MaNghe);
                        if (nghe != null)
                        {
                            item.TenNghe = nghe.TenDm;
                        }
                    }
                    ViewData["Cout"] = model.Count();
                    ViewData["TenTuyenDung"] = tuyendung!.NoiDung;
                    ViewData["TenDoanhNghiep"] = _db.Company.FirstOrDefault(x => x.Id == tuyendung.User)!.Name;

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cungcau";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CungCauLaoDong/DanhSachViTriTuyenDung.cshtml", model);
                }
                else
                {
                    ViewData["Messages"] = "Bạn không có quyền truy cập vào chức năng này!";
                    return View("Views/Admin/Error/Page.cshtml");
                }
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }
        [Route("TruyVanCungCauLD/DanhSachCungLDTuongUng")]
        [HttpPost]
        public IActionResult DanhSachCungLDTuongUng(string MaNghe,short IdTuyenDung)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.Where(x => x.NganhNgheMongMuon == MaNghe);
                    foreach (var item in model)
                    {
                        item.IdTuyenDung = IdTuyenDung;
                    }

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cungcau";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CungCauLaoDong/DanhSachCungLDTuongUng.cshtml", model);
                }
                else
                {
                    ViewData["Messages"] = "Bạn không có quyền truy cập vào chức năng này!";
                    return View("Views/Admin/Error/Page.cshtml");
                }
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
           
        }
        [Route("TruyVanCungCauLD/PrintMau03a")]
        [HttpGet]
        public IActionResult PrintMau03a(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var vitrituyendung = _db.ViTriTuyenDung.FirstOrDefault(x => x.Id == Id);
                    var tuyendung = _db.TuyenDung.FirstOrDefault(x => x.Id == vitrituyendung.IdTuyenDung);
                    var data = new VMTruyVanMau03aPL01()
                    {
                        ViTriTuyenDung = vitrituyendung,
                        TuyenDung = tuyendung,
                    };

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cungcau";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CungCauLaoDong/PrintMau03aPL01.cshtml", data);
                }
                else
                {
                    ViewData["Messages"] = "Bạn không có quyền truy cập vào chức năng này!";
                    return View("Views/Admin/Error/Page.cshtml");
                }
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }

    }
}
