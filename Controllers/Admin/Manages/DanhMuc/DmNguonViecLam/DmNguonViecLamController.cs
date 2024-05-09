using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.Danhmuc.DmNguonViecLam
{
    public class DmNguonViecLamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmNguonViecLamController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmNguonViecLam")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmNguonViecLam.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_nganhhoc";
                    return View("Views/Admin/Manages/Danhmuc/DmNguonViecLam/Index.cshtml", model);
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

        [Route("DmNguonViecLam/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmNguonViecLam request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmNguonViecLam
                    {
                        MaNguonViecLam = request.MaNguonViecLam,
                        TenNguonViecLam = request.TenNguonViecLam,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmNguonViecLam.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmNguonViecLam");
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

        [Route("DmNguonViecLam/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmNguonViecLam.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã nguồn việc làm</b></label>";
                result += "<input type='text' id='MaNguonViecLam_Edit' name='MaNguonViecLam' value='" + model.MaNguonViecLam + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên nguồn việc làm</b></label>";
                result += "<input type='text' id='TenNguonViecLam_Edit' name='TenNguonViecLam' value='" + model.TenNguonViecLam + "' class='form-control'/>";
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

        [Route("DmNguonViecLam/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmNguonViecLam request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmNguonViecLam.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaNguonViecLam = request.MaNguonViecLam;
                        model.TenNguonViecLam = request.TenNguonViecLam;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmNguonViecLam.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DmNguonViecLam");
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

        [Route("DmNguonViecLam/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmNguonViecLam.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmNguonViecLam.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmNguonViecLam");
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
