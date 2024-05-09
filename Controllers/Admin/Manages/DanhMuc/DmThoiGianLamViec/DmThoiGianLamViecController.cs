using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmThoiGianLamViec
{
    public class DmThoiGianLamViecController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmThoiGianLamViecController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmThoiGianLamViec")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmThoiGianLamViec.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_thoigianlamviec";
                    return View("Views/Admin/Manages/Danhmuc/DmThoiGianLamViec/Index.cshtml", model);
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

        [Route("DmThoiGianLamViec/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmThoiGianLamViec request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmThoiGianLamViec
                    {
                        MaThoiGianLamViec = request.MaThoiGianLamViec,
                        TenThoiGianLamViec = request.TenThoiGianLamViec,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmThoiGianLamViec.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmThoiGianLamViec");
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

        [Route("DmThoiGianLamViec/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmThoiGianLamViec.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã tình trạng việc làm</b></label>";
                result += "<input type='text' id='MaThoiGianLamViec_Edit' name='MaThoiGianLamViec' value='" + model.MaThoiGianLamViec + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên tình trạng việc làm</b></label>";
                result += "<input type='text' id='TenThoiGianLamViec_Edit' name='TenThoiGianLamViec' value='" + model.TenThoiGianLamViec + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả</b></label>";
                result += "<textarea type='text' id='MoTa' name='MoTa' cols='12' rows='3' class='form-control'>" + model.MoTa + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "</div>";

                result += "<input hidden type='text' id='Id' name='Id' value='" + model.Id + "'/>";
                result += "</div>";

                var data = new { status = "success", message = result };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Không tìm thấy thông tin cần chỉnh sửa!!!" };
                return Json(data);
            }
        }

        [Route("DmThoiGianLamViec/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmThoiGianLamViec request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmThoiGianLamViec.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaThoiGianLamViec = request.MaThoiGianLamViec;
                        model.TenThoiGianLamViec = request.TenThoiGianLamViec;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmThoiGianLamViec.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmThoiGianLamViec");
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

        [Route("DmThoiGianLamViec/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmThoiGianLamViec.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmThoiGianLamViec.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmThoiGianLamViec");
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
