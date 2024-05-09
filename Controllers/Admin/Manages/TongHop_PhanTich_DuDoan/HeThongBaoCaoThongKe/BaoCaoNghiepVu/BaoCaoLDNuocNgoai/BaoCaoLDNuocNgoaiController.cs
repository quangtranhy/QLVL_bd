using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.BaoCaoLDNuocNgoai
{
    public class BaoCaoLDNuocNgoaiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BaoCaoLDNuocNgoaiController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("BaoCaoLDNuocNgoai")]
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
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoLDNuocNgoai";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoLDNuocNgoai/Index.cshtml");
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
        [Route("BaoCaoLDNuocNgoai/Print")]
        [HttpGet]
        public IActionResult Print(string type)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["type"] = type;
                    var model = _db.NguoiLaoDong.AsQueryable();

                    if (type == "nuocngoai")
                    {
                        ViewData["nuocngoai"] = model.Where(x => x.Abroad != null);
                        ViewData["nameReport"] = " nguời lao động Việt Nam tại nước ngoài";
                    }

                    else
                    {
                        ViewData["trongnuoc"] = model.Where(x => x.Nation != "VN");
                        ViewData["nameReport"] = " người lao động nước ngoài tại Việt Nam";
                    }

                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoLDNuocNgoai";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoLDNuocNgoai/Print.cshtml");
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
