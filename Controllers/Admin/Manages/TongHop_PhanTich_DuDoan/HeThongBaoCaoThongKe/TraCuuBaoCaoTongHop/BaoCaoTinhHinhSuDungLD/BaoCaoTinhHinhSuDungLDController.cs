using Microsoft.AspNetCore.Mvc;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.TraCuuBaoCaoTongHop.BaoCaoTinhHinhSuDungLD
{
	public class BaoCaoTinhHinhSuDungLDController : Controller
	{
		[Route("BaoCaoTinhHinhSuDungLD")]
		[HttpGet]
		public IActionResult Print()
		{
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke_tracuubaocao";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_tracuubaocao_tinhhinhsudungld";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/TraCuuBaoCaoTongHop/BaoCaoTinhHinhSuDungLD/Print.cshtml");
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
