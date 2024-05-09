using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.ThongTinCung_Cau.NguonCungLaoDong
{
    public class NguonCungLaoDongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NguonCungLaoDongController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("NguonCungLaoDong")]
        [HttpGet]
        public IActionResult Index(string tinhtrang,string kydieutra)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    kydieutra = (string.IsNullOrEmpty(kydieutra)) ? "2022" : kydieutra;
                    var model = _db.NhanKhau.Where(x => x.KyDieuTra == kydieutra).AsQueryable();
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
                    ViewData["kydieutra"] = kydieutra;
                    //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");

                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_xemnguoncung";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/NguoiTimViec/Index.cshtml", model);
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
