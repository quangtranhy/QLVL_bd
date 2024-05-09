using Microsoft.AspNetCore.Mvc;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.BaoCaoTTThiTruongLD
{
    public class BaoCaoTTThiTruongLDController : Controller
    {
        [Route("BaoCaoTTThiTruongLD")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoTTThiTruongLD";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoTTThiTruongLD/BaoCaoTTThiTruongLD_Print.cshtml");
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
