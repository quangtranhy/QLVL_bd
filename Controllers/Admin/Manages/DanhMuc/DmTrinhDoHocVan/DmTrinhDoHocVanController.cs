
using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmTrinhDoHocVan
{
    public class DmTrinhDoHocVanController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmTrinhDoHocVanController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmTrinhDoHocVan")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoHocVan.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_trinhdohocvan";
                    return View("Views/Admin/Manages/Danhmuc/DmTrinhDoHocVan/Index.cshtml", model);
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

        [Route("DmTrinhDoHocVan/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmTrinhDoHocVan request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmTrinhDoHocVan
                    {
                        MaTrinhDoHocVan = request.MaTrinhDoHocVan,
                        TenTrinhDoHocVan = request.TenTrinhDoHocVan,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmTrinhDoHocVan.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmTrinhDoHocVan");
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

        [Route("DmTrinhDoHocVan/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {

            var model = _db.DmTrinhDoHocVan.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã tình trạng việc làm</b></label>";
                result += "<input type='text' id='MaTrinhDoHocVan_Edit' name='MaTrinhDoHocVan' value='" + model.MaTrinhDoHocVan + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên tình trạng việc làm</b></label>";
                result += "<input type='text' id='TenTrinhDoHocVan_Edit' name='TenTrinhDoHocVan' value='" + model.TenTrinhDoHocVan + "' class='form-control'/>";
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

        [Route("DmTrinhDoHocVan/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmTrinhDoHocVan request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoHocVan.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaTrinhDoHocVan = request.MaTrinhDoHocVan;
                        model.TenTrinhDoHocVan = request.TenTrinhDoHocVan;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmTrinhDoHocVan.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrinhDoHocVan");
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

        [Route("DmTrinhDoHocVan/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoHocVan.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmTrinhDoHocVan.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrinhDoHocVan");
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
