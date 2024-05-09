using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.BaoCaoThongKeTheoDVHC
{
    public class BaoCaoThongKeTheoDVHCController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BaoCaoThongKeTheoDVHCController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("BaoCaoThongKeTheoDVHC")]
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
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoThongKeTheoDVHC";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoThongKeTheoDVHC/Index.cshtml");
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
        [Route("BaoCaoThongKeTheoDVHC/Print")]
        [HttpGet]
        public IActionResult Print(string type)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["type"] = type;

                    var model = _db.NhanKhau.AsQueryable();

                    if (type == "tinhtrang")
                    {
                        var tinhtrang = model.GroupBy(x => x.ThatNghiep)
                            .Select(group => new VM_Count_LucLuongLD
                            {
                                Mota = group.Key,
                                Count = group.Count(),
                            });
                        ViewData["tinhtrang"] = tinhtrang;
                        ViewData["nameReport"] = "tình trạng thất nghiệp";
                    }

                    if (type == "dvhc")
                    {
                        var dvhc = model.GroupBy(x => x.MaDonVi)
                            .Select(group => new VM_Count_LucLuongLD
                            {
                                Mota = group.Key,
                                Count = group.Count(),
                            });
                        ViewData["dvhc"] = dvhc;
                        ViewData["nameReport"] = "đơn vị hành chính";
                    }

                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoThongKeTheoDVHC";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoThongKeTheoDVHC/Print.cshtml");
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
