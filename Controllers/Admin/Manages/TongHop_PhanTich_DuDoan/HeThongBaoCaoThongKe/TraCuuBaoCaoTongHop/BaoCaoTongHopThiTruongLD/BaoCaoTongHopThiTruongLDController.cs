using Microsoft.AspNetCore.Mvc;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.TraCuuBaoCaoTongHop.BaoCaoTongHopThiTruongLD
{
    public class BaoCaoTongHopThiTruongLDController : Controller
    {
        [Route("BaoCaoTongHopThiTruongLD")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke_tracuubaocao";
                    ViewData["MenuLv3"] = "menu_hethongbaocaothongke_tracuubaocao_BaoCaoTongHopThiTruongLD";

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
