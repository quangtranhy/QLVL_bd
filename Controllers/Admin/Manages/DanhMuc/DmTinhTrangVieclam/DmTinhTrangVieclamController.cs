using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmTinhTrangViecLam
{
    public class DmTinhTrangViecLamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmTinhTrangViecLamController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmTinhTrangViecLam")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTinhTrangViecLam.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_DmTinhTrangViecLam";
                    return View("Views/Admin/Manages/Danhmuc/DmTinhTrangViecLam/Index.cshtml", model);
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

        [Route("DmTinhTrangViecLam/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmTinhTrangViecLam request)
        {
            var model = new Models.Admin.Manages.DanhMuc.DmTinhTrangViecLam
            {
                MaTinhTrangViecLam = request.MaTinhTrangViecLam,
                TenTinhTrangViecLam = request.TenTinhTrangViecLam,
                MoTa = request.MoTa,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DmTinhTrangViecLam.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "DmTinhTrangViecLam");
        }

        [Route("DmTinhTrangViecLam/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmTinhTrangViecLam.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã tình trạng việc làm</b></label>";
                result += "<input type='text' id='MaTinhTrangViecLam_Edit' name='MaTinhTrangViecLam' value='" + model.MaTinhTrangViecLam + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên tình trạng việc làm</b></label>";
                result += "<input type='text' id='TenTinhTrangViecLam_Edit' name='TenTinhTrangViecLam' value='" + model.TenTinhTrangViecLam + "' class='form-control'/>";
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

        [Route("DmTinhTrangViecLam/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmTinhTrangViecLam request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTinhTrangViecLam.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaTinhTrangViecLam = request.MaTinhTrangViecLam;
                        model.TenTinhTrangViecLam = request.TenTinhTrangViecLam;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmTinhTrangViecLam.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTinhTrangViecLam");
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

        [Route("DmTinhTrangViecLam/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTinhTrangViecLam.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmTinhTrangViecLam.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTinhTrangViecLam");
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
