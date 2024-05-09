using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmTrangThaiViecLam
{
    public class DmTrangThaiViecLamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmTrangThaiViecLamController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmTrangThaiViecLam")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrangThaiViecLam.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_trangthaivieclam";
                    return View("Views/Admin/Manages/Danhmuc/DmTrangThaiViecLam/Index.cshtml", model);
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

        [Route("DmTrangThaiViecLam/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmTrangThaiViecLam request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmTrangThaiViecLam
                    {
                        MaTrangThaiViecLam = request.MaTrangThaiViecLam,
                        TenTrangThaiViecLam = request.TenTrangThaiViecLam,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmTrangThaiViecLam.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmTrangThaiViecLam");
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

        [Route("DmTrangThaiViecLam/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmTrangThaiViecLam.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã trạng thái việc làm</b></label>";
                result += "<input type='text' id='MaTrangThaiViecLam_Edit' name='MaTrangThaiViecLam' value='" + model.MaTrangThaiViecLam + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên trạng thái việc làm</b></label>";
                result += "<input type='text' id='TenTrangThaiViecLam_Edit' name='TenTrangThaiViecLam' value='" + model.TenTrangThaiViecLam + "' class='form-control'/>";
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

        [Route("DmTrangThaiViecLam/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmTrangThaiViecLam request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrangThaiViecLam.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaTrangThaiViecLam = request.MaTrangThaiViecLam;
                        model.TenTrangThaiViecLam = request.TenTrangThaiViecLam;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmTrangThaiViecLam.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrangThaiViecLam");
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

        [Route("DmTrangThaiViecLam/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrangThaiViecLam.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmTrangThaiViecLam.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrangThaiViecLam");
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
