using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using System.Collections.Generic;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.TraCuuBaoCaoTongHop.TraCuuTTCungCauLD
{
    public class TraCuuTTCungCauLDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TraCuuTTCungCauLDController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("TraCuuTTCungCauLD")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["Title"] = "Kế hoạch thu thập thông tin lao động";
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_tracuubaocao";
                    ViewData["MenuLv3"] = "menu_hethongbaocaothongke_tracuubaocao_TraCuuTTCungCauLD";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/TraCuuBaoCaoTongHop/TraCuuTTCungCauLD/Index.cshtml");
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
        [Route("TraCuuTTCungCauLD/CauLaoDong")]
        [HttpGet]
        public IActionResult CauLaoDong(string time)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var allCompany = _db.TuyenDung.GroupBy(x => x.User);
                    var company = new List<Company>();
                    var alltime = _db.TuyenDung.GroupBy(x => x.ThoiHan.Year.ToString());

                    foreach (var item in allCompany)
                    {
                        company.Add(_db.Company.FirstOrDefault(x => x.Id == item.Key)!);
                    }
                    ViewBag.Time = new SelectList(alltime.Select(x => x.Key).ToList());

                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_tracuubaocao";
                    ViewData["MenuLv3"] = "menu_hethongbaocaothongke_tracuubaocao_TraCuuTTCungCauLD";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/TraCuuBaoCaoTongHop/TraCuuTTCungCauLD/CauLaoDong.cshtml", company);
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
        [Route("TraCuuTTCungCauLD/CungLaoDong")]
        [HttpGet]
        public IActionResult CungLaoDong(string time)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.AsQueryable();
                    var takeLastTime = _db.NhanKhau.OrderByDescending(x => x.Id).FirstOrDefault()!.KyDieuTra;
                    if (time == null)
                    {
                        model = model.Where(x => x.KyDieuTra == takeLastTime);
                    }
                    else
                    {
                        model = model.Where(x => x.KyDieuTra == time);
                    }
                    var alltime = _db.TuyenDung.GroupBy(x => x.ThoiHan.Year.ToString());

                    ViewBag.Time = new SelectList(alltime.Select(x => x.Key).ToList());

                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_tracuubaocao";
                    ViewData["MenuLv3"] = "menu_hethongbaocaothongke_tracuubaocao_TraCuuTTCungCauLD";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/TraCuuBaoCaoTongHop/TraCuuTTCungCauLD/CungLaoDong.cshtml", model);
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
