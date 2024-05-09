using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.BaoCaoNhuCauGiaiQuyetVl
{
    public class BaoCaoNhuCauGiaiQuyetVlController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BaoCaoNhuCauGiaiQuyetVlController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("BaoCaoNhuCauGiaiQuyetVl")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {

                    var allCompany = _db.TuyenDung.GroupBy(x => x.User);
                    var model = new List<Company>();
                    foreach (var item in allCompany)
                    {
                        model.Add(_db.Company.FirstOrDefault(x => x.Id == item.Key)!);
                    }

                    ViewData["Total"] = model.Count();
                    ViewData["Title"] = "Kế hoạch thu thập thông tin lao động";
                    ViewData["MenuLv1"] = "";
                    ViewData["MenuLv2"] = "";
                    ViewData["MenuLv3"] = "";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoNhuCauGiaiQuyetVl/Index.cshtml", model);
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
