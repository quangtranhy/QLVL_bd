using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmTonGiao
{
    public class DmTonGiaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmTonGiaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmTonGiao")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTonGiao.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_tongiao";
                    return View("Views/Admin/Manages/Danhmuc/DmTonGiao/Index.cshtml", model);
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

        [Route("DmTonGiao/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmTonGiao request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmTonGiao
                    {
                        MaTonGiao = request.MaTonGiao,
                        TenTonGiao = request.TenTonGiao,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmTonGiao.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmTonGiao");
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

        [Route("DmTonGiao/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmTonGiao.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã tôn giáo</b></label>";
                result += "<input type='text' id='MaTonGiao_Edit' name='MaTonGiao' value='" + model.MaTonGiao + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên tôn giáo</b></label>";
                result += "<input type='text' id='TenTonGiao_Edit' name='TenTonGiao' value='" + model.TenTonGiao + "' class='form-control'/>";
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

        [Route("DmTonGiao/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmTonGiao request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTonGiao.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaTonGiao = request.MaTonGiao;
                        model.TenTonGiao = request.TenTonGiao;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmTonGiao.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTonGiao");
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

        [Route("DmTonGiao/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTonGiao.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmTonGiao.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTonGiao");
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
