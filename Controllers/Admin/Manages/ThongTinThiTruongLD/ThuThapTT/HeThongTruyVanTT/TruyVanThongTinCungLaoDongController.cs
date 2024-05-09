using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.HeThongTruyVanTT;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.TruyVanThongTinLaoDong
{
    public class TruyVanThongTinCungLaoDongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TruyVanThongTinCungLaoDongController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("TruyVanThongTinCungLaoDong/VanTinKiemTraXacThucCungLD")]
        public IActionResult VanTinKiemTraXacThucCungLD( string tinhtrang, string huyen, string xa, string kydieutra, Boolean TinhTrangXacThuc)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var DmHuyen= _db.DmHanhChinh.Where(t => t.CapDo == "H");
                var DmXa = _db.DmHanhChinh.Where(x=>x.CapDo=="X");
                huyen = string.IsNullOrEmpty(huyen)? DmHuyen.FirstOrDefault()!.MaQuocGia! : huyen;
                xa = string.IsNullOrEmpty(xa)? DmXa.FirstOrDefault()!.Id.ToString()! : xa;                
                var donvi = _db.DmDonvi.FirstOrDefault(x=>x.MaDiaBan==xa);
                var Madv = "";
                if (donvi == null)
                {
                    Madv = _db.DmDonvi.FirstOrDefault()!.MaDonVi;
                }
                else
                {
                    Madv = donvi!.MaDonVi;
                }                
                kydieutra = (string.IsNullOrEmpty(kydieutra)) ? "2022" : kydieutra;
                var model = _db.NhanKhau.Where(x => x.MaDonVi == Madv && x.KyDieuTra == kydieutra && x.TinhTrangXacThuc==TinhTrangXacThuc).AsQueryable();
                if (!string.IsNullOrEmpty(tinhtrang))
                {
                    if (tinhtrang == "1")
                    {
                        model = model.Where(x => x.TinhTrangHdkt == "1");
                    }
                    if (tinhtrang == "2")
                    {
                        model = model.Where(x => x.TinhTrangHdkt == "2");
                    }
                    if (tinhtrang == "3")
                    {
                        model = model.Where(x => x.TinhTrangHdkt == "3");
                    }
                }
                /*if (loai == null)
                {
                    model = model.Where(x => x.nguoicovieclam == "1");
                }*/
                ViewData["TinhTrangXacThuc"] = TinhTrangXacThuc;
                ViewData["tinhtrang"] = tinhtrang;
                ViewData["mahuyen"] = huyen;
                ViewData["maxa"] = xa;
                ViewData["kydieutra"] = kydieutra;
                //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
                ViewData["Huyen"] = DmHuyen;
                if (string.IsNullOrEmpty(xa))
                {
                    ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X");
                }
                else
                {
                    ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X" && t.Parent == huyen);
                }

                ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cung";
                return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CungLaoDong/Index.cshtml", model);

            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }
        [Route("TruyVanThongTinCungLaoDong/Print")]
        [HttpGet]
        public IActionResult Print(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.FirstOrDefault(x => x.Id == Id);
                    ViewData["Id"] = Id;
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cung";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CungLaoDong/Print.cshtml");
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
        [Route("TruyVanThongTinCungLaoDong/XacThuc")]
        [HttpGet]
        public IActionResult XacThuc(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.Where(x => x.Id == Id).FirstOrDefault()!;
                    model.TinhTrangXacThuc = true;
                    _db.SaveChanges();
                    var madiabandv = _db.DmDonvi.FirstOrDefault(x => x.MaDonVi == model.MaDonVi)!.MaDiaBan;
                    var maxa = _db.DmHanhChinh.FirstOrDefault(x => x.Id == Convert.ToInt32(madiabandv))!.Id;
                    return RedirectToAction("VanTinKiemTraXacThucCungLD", "TruyVanThongTinCungLaoDong", new { xa = maxa, tinhtrang = model.TinhTrangHdkt, kydieutra = model.KyDieuTra, TinhTrangXacThuc = model.TinhTrangXacThuc });
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
