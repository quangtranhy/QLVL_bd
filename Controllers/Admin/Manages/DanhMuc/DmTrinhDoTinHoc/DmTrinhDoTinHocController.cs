using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmTrinhDoTinHoc
{
    public class DmTrinhDoTinHocController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmTrinhDoTinHocController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmTrinhDoTinHoc")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoTinHoc.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_TrinhDoTinHoc";
                    return View("Views/Admin/Manages/Danhmuc/DmTrinhDoTinHoc/Index.cshtml", model);
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

        [Route("DmTrinhDoTinHoc/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmTrinhDoTinHoc request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmTrinhDoTinHoc
                    {
                        MaTrinhDoTinHoc = request.MaTrinhDoTinHoc,
                        TenTrinhDoTinHoc = request.TenTrinhDoTinHoc,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmTrinhDoTinHoc.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmTrinhDoTinHoc");
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

        [Route("DmTrinhDoTinHoc/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmTrinhDoTinHoc.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã trình độ tin học</b></label>";
                result += "<input type='text' id='MaTrinhDoTinHoc_Edit' name='MaTrinhDoTinHoc' value='" + model.MaTrinhDoTinHoc + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên trình độ tin học</b></label>";
                result += "<input type='text' id='TenTrinhDoTinHoc_Edit' name='TenTrinhDoTinHoc' value='" + model.TenTrinhDoTinHoc + "' class='form-control'/>";
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

        [Route("DmTrinhDoTinHoc/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmTrinhDoTinHoc request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoTinHoc.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaTrinhDoTinHoc = request.MaTrinhDoTinHoc;
                        model.TenTrinhDoTinHoc = request.TenTrinhDoTinHoc;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmTrinhDoTinHoc.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrinhDoTinHoc");
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

        [Route("DmTrinhDoTinHoc/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoTinHoc.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmTrinhDoTinHoc.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrinhDoTinHoc");
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
