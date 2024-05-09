using Microsoft.AspNetCore.Mvc;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT.SoGhiChepTTLD
{
    public class SoGhiChepTTLDController : Controller
    {
        [Route("SoGhiChepTTLD")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_SoGhiChepTTLD";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/SoGhiChepTTLD/Index.cshtml");
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
        [Route("SoGhiChepTTLD/CungLaoDong")]
        [HttpGet]
        public IActionResult CungLaoDong()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/SoGhiChepTTLD/CungLD_Print.cshtml");
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
        [Route("SoGhiChepTTLD/CauLaoDong")]
        [HttpGet]
        public IActionResult CauLaoDong()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/SoGhiChepTTLD/CauLD_Print.cshtml");
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
