using Microsoft.AspNetCore.Mvc;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.XuatBaoCaoTTCungCau
{
    public class XuatBaoCaoTTCungCauController : Controller
    {
        [Route("XuatBaoCaoTTCungCau")]
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
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_xuatbaocao";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/XuatBaoCaoTTCungCau/Index.cshtml");
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
        [Route("XuatBaoCaoTTCungCau/CauLD")]
        [HttpGet]
        public IActionResult CauLD()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_xuatbaocao";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/XuatBaoCaoTTCungCau/CauLD_Print.cshtml");
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
        [Route("XuatBaoCaoTTCungCau/CungLD")]
        [HttpGet]
        public IActionResult CungLD()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_xuatbaocao";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/XuatBaoCaoTTCungCau/CungLD_Print.cshtml");
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
