using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT.NhuCauTuyenDungLD
{
    public class NhuCauTuyenDungLDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NhuCauTuyenDungLDController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("NhuCauTuyenDungLD")]
        [HttpGet]
        public IActionResult Index(string huyen, string xa)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    if (huyen == null || huyen == "")
                    {
                        huyen = _db.DmHanhChinh.Where(x => x.CapDo == "H").FirstOrDefault()!.Name!;
                    }

                    var parent = _db.DmHanhChinh.Where(x => x.CapDo == "H" && x.Name == huyen).FirstOrDefault()!.MaQuocGia;

                    if (string.IsNullOrEmpty(xa))
                    {
                        xa = _db.DmHanhChinh.Where(x => x.CapDo == "X" && x.Parent == parent).FirstOrDefault()!.Name!;
                    }

                    var allCompany = _db.TuyenDung.GroupBy(x => x.User);
                    var company = new List<Company>();
                    foreach (var item in allCompany)
                    {
                        company.Add(_db.Company.FirstOrDefault(x => x.Id == item.Key)!);
                    }
                    var model = company.Where(x => x.Xa == xa);
                    ViewData["tenhuyen"] = huyen;
                    ViewData["tenxa"] = xa;
                    //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");
                    ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X" && t.Parent == parent);
                    ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;

                    ViewData["Title"] = "Kế hoạch thu thập thông tin lao động";
                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_nhucautuyendung";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/NhuCauTuyenDungLD/Index.cshtml", model);
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
        [Route("NhuCauTuyenDungLD/Print")]
        [HttpGet]
        public IActionResult Print()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/NhuCauTuyenDungLD/NhuCauTuyenDungLD_Print.cshtml");
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
