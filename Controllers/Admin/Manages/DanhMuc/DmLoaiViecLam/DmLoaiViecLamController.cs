using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.Danhmuc.DmLoaiViecLam
{
    public class DmLoaiViecLamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmLoaiViecLamController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmLoaiViecLam")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiViecLam.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_loaivieclam";
                    return View("Views/Admin/Manages/Danhmuc/DmLoaiViecLam/Index.cshtml", model);
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

        [Route("DmLoaiViecLam/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmLoaiViecLam request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmLoaiViecLam
                    {
                        MaLoaiViecLam = request.MaLoaiViecLam,
                        TenLoaiViecLam = request.TenLoaiViecLam,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmLoaiViecLam.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmLoaiViecLam");
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

        [Route("DmLoaiViecLam/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmLoaiViecLam.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã loại việc làm</b></label>";
                result += "<input type='text' id='MaLoaiViecLam_Edit' name='MaLoaiViecLam' value='" + model.MaLoaiViecLam + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên loại việc làm</b></label>";
                result += "<input type='text' id='TenLoaiViecLam_Edit' name='TenLoaiViecLam' value='" + model.TenLoaiViecLam + "' class='form-control'/>";
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

        [Route("DmLoaiViecLam/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmLoaiViecLam request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiViecLam.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaLoaiViecLam = request.MaLoaiViecLam;
                        model.TenLoaiViecLam = request.TenLoaiViecLam;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmLoaiViecLam.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DmLoaiViecLam");
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

        [Route("DmLoaiViecLam/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiViecLam.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmLoaiViecLam.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmLoaiViecLam");
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
