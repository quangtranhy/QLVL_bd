using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.BaoCaoTaiNanLD
{
    public class BaoCaoTaiNanLDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BaoCaoTaiNanLDController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("BaoCaoTaiNanLD")]
        [HttpGet]
        public IActionResult Print()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = (from nld in _db.NguoiLaoDong
                                 join tnld in _db.TaiNanLaoDong
                                 on nld.Id.ToString() equals tnld.IdNguoiLaoDong
                                 join rr in _db.RuiRoLamViec
                                 on tnld.MaRuiro.ToString() equals rr.MaRuiro
                                 select new VM_TaiNanLaoDong
                                 {
                                     IdNguoiLaoDong = tnld.IdNguoiLaoDong,
                                     MaRuiro = tnld.MaRuiro,
                                     HoTen = nld.HoTen,
                                     TenRuiro = rr.TenRuiro,
                                     Mota = tnld.Mota,
                                 });
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoTaiNanLD";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoTaiNanLD/Print.cshtml");
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
