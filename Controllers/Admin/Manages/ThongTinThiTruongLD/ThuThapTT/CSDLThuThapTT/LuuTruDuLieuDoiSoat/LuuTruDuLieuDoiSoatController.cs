using Microsoft.AspNetCore.Mvc;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT.LuuTruDuLieuDoiSoat
{
    public class LuuTruDuLieuDoiSoatController : Controller
    {
        [Route("LuuTruDuLieuDoiSoat/Print")]
        [HttpGet]
        public IActionResult Print()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_LuuTruDuLieuDoiSoat";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/LuuTruDuLieuDoiSoat/Print.cshtml");
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
