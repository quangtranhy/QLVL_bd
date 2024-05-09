using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT.LuuTruTTTongHop
{
    public class LuuTruTTTongHopController : Controller
    {
        [Route("LuuTruTTTongHop")]
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
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_LuuTruTTTongHop";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/LuuTruTTTongHop/Index.cshtml");
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
        [Route("LuuTruTTTongHop/TongHopXa")]
        [HttpGet]
        public IActionResult TongHopXa()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/LuuTruTTTongHop/TongHopXa.cshtml");
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
        [Route("LuuTruTTTongHop/TongHopHuyen")]
        [HttpGet]
        public IActionResult TongHopHuyen()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/LuuTruTTTongHop/TongHopHuyen.cshtml");
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
        [Route("LuuTruTTTongHop/TongHopTinh")]
        [HttpGet]
        public IActionResult TongHopTinh()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/LuuTruTTTongHop/TongHopTinh.cshtml");
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
