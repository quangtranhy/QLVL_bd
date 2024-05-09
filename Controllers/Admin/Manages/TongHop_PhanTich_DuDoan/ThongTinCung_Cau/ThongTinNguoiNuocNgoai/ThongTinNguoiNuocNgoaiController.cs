using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.ThongTinCung_Cau.ThongTinNguoiNuocNgoai
{
    public class ThongTinNguoiNuocNgoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ThongTinNguoiNuocNgoaiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("ThongTinNguoiNuocNgoai")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NguoiLaoDong.Where(x => x.Nation != "VN");
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtinlaodongnuocngoai";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/ThongTinNguoiNuocNgoai/Index.cshtml", model);
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
