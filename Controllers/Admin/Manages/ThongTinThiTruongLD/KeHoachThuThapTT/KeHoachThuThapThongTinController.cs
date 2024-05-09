using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Helper;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.KeHoachThuThapTT
{
    public class KeHoachThuThapThongTinController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KeHoachThuThapThongTinController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("KeHoachThuThapThongTin")]
        public IActionResult Index(int Nam)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    Nam = Nam == 0 ? DateTime.Now.Year : Nam;
                    var model = _db.KeHoachThuThapThongTin.Where(t => t.NgayLapKeHoach.Year == Nam);

                    ViewData["Title"] = "Kế hoạch thu thập thông tin lao động";
                    ViewData["MenuLv1"] = "menu_kehoachthuthapthongtin";
                    ViewData["MenuLv2"] = "menu_kehoachthuthapthongtin_danhsach";
                    ViewData["Nam"] = Nam;
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/KeHoachThuThapTT/DanhSach/Index.cshtml", model);
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

        [HttpGet("KeHoachThuThapThongTin/Create")]
        public IActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new KeHoachThuThapThongTin
                    {
                        MaKeHoach = "KH_" + DateTime.Now.ToString("yymmssfff"),
                        NgayLapKeHoach = DateTime.Now,
                        Status = "CC"
                    };

                    ViewData["Title"] = "Kế hoạch thu thập thông tin lao động";
                    ViewData["MenuLv1"] = "menu_kehoachthuthapthongtin";
                    ViewData["MenuLv2"] = "menu_kehoachthuthapthongtin_danhsach";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/KeHoachThuThapTT/DanhSach/Create.cshtml", model);
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

        [HttpPost]
        public IActionResult Store(KeHoachThuThapThongTin requests)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    _db.KeHoachThuThapThongTin.Add(requests);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "KeHoachThuThapThongTin", new { Nam = requests.NgayLapKeHoach.Year });
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

        [HttpGet("KeHoachThuThapThongTin/Edit")]
        public IActionResult Edit(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        ViewData["Title"] = "Kế hoạch thu thập thông tin lao động";
                        ViewData["MenuLv1"] = "menu_kehoachthuthapthongtin";
                        ViewData["MenuLv2"] = "menu_kehoachthuthapthongtin_danhsach";
                        return View("Views/Admin/Manages/ThongTinThiTruongLD/KeHoachThuThapTT/DanhSach/Edit.cshtml", model);
                    }
                    else
                    {
                        ViewData["Messages"] = "Không thể chỉnh sửa thông tin!";
                        return View("Views/Admin/Error/Page.cshtml");
                    }
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

        [HttpPost]
        public IActionResult Update(KeHoachThuThapThongTin requests)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == requests.Id);
                    if (model != null)
                    {
                        _db.KeHoachThuThapThongTin.Update(requests);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "KeHoachThuThapThongTin", new { Nam = requests.NgayLapKeHoach.Year });
                    }
                    else
                    {
                        ViewData["Messages"] = "Không thể chỉnh sửa thông tin!";
                        return View("Views/Admin/Error/Page.cshtml");
                    }
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

        [HttpPost("KeHoachThuThapThongTin/Remove")]
        public JsonResult Remove(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id)!;
                if (model != null)
                {
                    _db.KeHoachThuThapThongTin.Remove(model);
                    _db.SaveChanges();
                }
                var data = new { status = "success", message = "Cập nhật thành công" };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Bạn kêt thúc phiên đăng nhập! Đăng nhập lại để tiếp tục công việc" };
                return Json(data);
            }
        }

        [HttpPost("KeHoachThuThapThongTin/ChuyenXetDuyet")]
        public JsonResult ChuyenXetDuyet(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id)!;
                if (model != null)
                {
                    model.Status = "CD";
                    _db.KeHoachThuThapThongTin.Update(model);
                    _db.SaveChanges();
                }
                var data = new { status = "success", message = "Cập nhật thành công" };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Bạn kêt thúc phiên đăng nhập! Đăng nhập lại để tiếp tục công việc" };
                return Json(data);
            }
        }

        [HttpGet("KeHoachThuThapThongTin/Show")]
        public IActionResult Show(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        if (model.Status == "DD")
                        {
                            ViewData["TenDonViBaoCao"] = "ỦY BAN NHÂN DÂN";
                            ViewData["NgayDuyetKeHoach"] = Funtions_Global.ConvertDateToText(model.NgayKyKeHoach);
                        }
                        ViewData["Title"] = "Kế hoạch thu thập thông tin lao động";
                        return View("Views/Admin/Manages/ThongTinThiTruongLD/KeHoachThuThapTT/DanhSach/Show.cshtml", model);
                    }
                    else
                    {
                        ViewData["Messages"] = "Không tìm thấy thông tin!";
                        return View("Views/Admin/Error/Page.cshtml");
                    }
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
