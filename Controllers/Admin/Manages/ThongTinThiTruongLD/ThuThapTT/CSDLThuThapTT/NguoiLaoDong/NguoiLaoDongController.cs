using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT.NguoiLaoDong
{
    public class NguoiLaoDongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NguoiLaoDongController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("NguoiLaoDong")]
        [HttpGet]
        public IActionResult Index(string tinhtrang, string huyen, string xa, string kydieutra)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var Madv = "";
                    if (string.IsNullOrEmpty(xa))
                    {
                        Madv = _db.DmDonvi.FirstOrDefault()!.MaDonVi!;
                    }
                    else
                    {
                        Madv = _db.DmDonvi.Where(x => x.MaDiaBan == xa).FirstOrDefault()!.MaDonVi!;
                    }

                    kydieutra = (string.IsNullOrEmpty(kydieutra)) ? "2022" : kydieutra;
                    var model = _db.NhanKhau.Where(x => x.MaDonVi == Madv && x.KyDieuTra == kydieutra).AsQueryable();
                    if (string.IsNullOrEmpty(tinhtrang))
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
                    ViewData["tinhtrang"] = tinhtrang;
                    ViewData["mahuyen"] = huyen;
                    ViewData["maxa"] = xa;
                    ViewData["kydieutra"] = kydieutra;
                    //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");
                    if (string.IsNullOrEmpty(xa))
                    {
                        ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X");
                    }
                    else
                    {
                        ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X" && t.Parent == huyen);
                    }

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_nguoilaodong";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/NguoiLaoDong/Index.cshtml", model);
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

        [Route("NguoiLaoDong/Print")]
        [HttpGet]
        public IActionResult Print()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/NguoiLaoDong/NguoiLaoDong_Print.cshtml");
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
