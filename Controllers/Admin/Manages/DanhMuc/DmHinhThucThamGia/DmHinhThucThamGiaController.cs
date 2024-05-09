using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.Danhmuc.DmHinhThucThamGia
{
    public class DmHinhThucThamGiaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmHinhThucThamGiaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmHinhThucThamGia")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmHinhThucThamGia.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_hinhthuctg";
                    return View("Views/Admin/Manages/Danhmuc/DmHinhThucThamGia/Index.cshtml", model);
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

        [Route("DmHinhThucThamGia/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmHinhThucThamGia request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmHinhThucThamGia
                    {
                        MaHinhThucThamGia = request.MaHinhThucThamGia,
                        TenHinhThucThamGia = request.TenHinhThucThamGia,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmHinhThucThamGia.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmHinhThucThamGia");
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

        [Route("DmHinhThucThamGia/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmHinhThucThamGia.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã quốc gia</b></label>";
                result += "<input type='text' id='MaHinhThucThamGia_Edit' name='MaHinhThucThamGia' value='" + model.MaHinhThucThamGia + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên quốc gia</b></label>";
                result += "<input type='text' id='TenHinhThucThamGia_Edit' name='TenHinhThucThamGia' value='" + model.TenHinhThucThamGia + "' class='form-control'/>";
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

        [Route("DmHinhThucThamGia/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmHinhThucThamGia request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmHinhThucThamGia.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaHinhThucThamGia = request.MaHinhThucThamGia;
                        model.TenHinhThucThamGia = request.TenHinhThucThamGia;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmHinhThucThamGia.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DmHinhThucThamGia");
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

        [Route("DmHinhThucThamGia/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmHinhThucThamGia.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmHinhThucThamGia.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmHinhThucThamGia");
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
