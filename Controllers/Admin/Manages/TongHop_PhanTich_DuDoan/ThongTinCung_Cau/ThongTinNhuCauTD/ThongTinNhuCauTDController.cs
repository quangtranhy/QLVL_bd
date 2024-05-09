using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.ThongTinCung_Cau.ThongTinNhuCauTD
{
    public class ThongTinNhuCauTDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ThongTinNhuCauTDController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("ThongTinNhuCauTD")]
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
                    var model = _db.Company.Where(x => x.Xa == xa);
                    ViewData["tenhuyen"] = huyen;
                    ViewData["tenxa"] = xa;
                    //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");
                    ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X" && t.Parent == parent);
                    ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;

                    ViewData["Title"] = "";
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtinnhucautdlaodong";
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
    }
}
