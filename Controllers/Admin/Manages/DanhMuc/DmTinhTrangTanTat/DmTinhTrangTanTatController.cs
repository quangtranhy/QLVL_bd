using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.Danhmuc.DmTinhTrangTanTat
{
    public class DmTinhTrangTanTatController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmTinhTrangTanTatController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmTinhTrangTanTat")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTinhTrangTanTat.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_tantat";
                    return View("Views/Admin/Manages/Danhmuc/DmTinhTrangTanTat/Index.cshtml", model);
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

        [Route("DmTinhTrangTanTat/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmTinhTrangTanTat request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmTinhTrangTanTat
                    {
                        MaTinhTrangTanTat = request.MaTinhTrangTanTat,
                        TenTinhTrangTanTat = request.TenTinhTrangTanTat,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmTinhTrangTanTat.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmTinhTrangTanTat");
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

        [Route("DmTinhTrangTanTat/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmTinhTrangTanTat.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã tình trạng tàn tật</b></label>";
                result += "<input type='text' id='MaTinhTrangTanTat_Edit' name='MaTinhTrangTanTat' value='" + model.MaTinhTrangTanTat + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên tình trạng tàn tật</b></label>";
                result += "<input type='text' id='TenTinhTrangTanTat_Edit' name='TenTinhTrangTanTat' value='" + model.TenTinhTrangTanTat + "' class='form-control'/>";
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

        [Route("DmTinhTrangTanTat/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmTinhTrangTanTat request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTinhTrangTanTat.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaTinhTrangTanTat = request.MaTinhTrangTanTat;
                        model.TenTinhTrangTanTat = request.TenTinhTrangTanTat;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmTinhTrangTanTat.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DmTinhTrangTanTat");
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

        [Route("DmTinhTrangTanTat/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTinhTrangTanTat.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmTinhTrangTanTat.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTinhTrangTanTat");
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
