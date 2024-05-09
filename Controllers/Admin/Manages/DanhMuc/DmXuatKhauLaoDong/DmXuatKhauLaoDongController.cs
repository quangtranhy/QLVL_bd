using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmXuatKhauLaoDong
{
    public class DmXuatKhauLaoDongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmXuatKhauLaoDongController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmXuatKhauLaoDong")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmXuatKhauLaoDong.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_xuatkhauld";
                    return View("Views/Admin/Manages/Danhmuc/DmXuatKhauLaoDong/Index.cshtml", model);
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

        [Route("DmXuatKhauLaoDong/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmXuatKhauLaoDong request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmXuatKhauLaoDong
                    {
                        MaXuatKhauLaoDong = request.MaXuatKhauLaoDong,
                        TenXuatKhauLaoDong = request.TenXuatKhauLaoDong,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmXuatKhauLaoDong.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmXuatKhauLaoDong");
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

        [Route("DmXuatKhauLaoDong/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmXuatKhauLaoDong.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã xuất khẩu lao động</b></label>";
                result += "<input type='text' id='MaXuatKhauLaoDong_Edit' name='MaXuatKhauLaoDong' value='" + model.MaXuatKhauLaoDong + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên xuất khẩu lao động</b></label>";
                result += "<input type='text' id='TenXuatKhauLaoDong_Edit' name='TenXuatKhauLaoDong' value='" + model.TenXuatKhauLaoDong + "' class='form-control'/>";
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

        [Route("DmXuatKhauLaoDong/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmXuatKhauLaoDong request)
        {
            var model = _db.DmXuatKhauLaoDong.FirstOrDefault(t => t.Id == request.Id);
            if (model != null)
            {
                model.MaXuatKhauLaoDong = request.MaXuatKhauLaoDong;
                model.TenXuatKhauLaoDong = request.TenXuatKhauLaoDong;
                model.MoTa = request.MoTa;
                model.Updated_at = DateTime.Now;
                _db.DmXuatKhauLaoDong.Update(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "DmXuatKhauLaoDong");
        }

        [Route("DmXuatKhauLaoDong/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmXuatKhauLaoDong.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmXuatKhauLaoDong.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmXuatKhauLaoDong");
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
