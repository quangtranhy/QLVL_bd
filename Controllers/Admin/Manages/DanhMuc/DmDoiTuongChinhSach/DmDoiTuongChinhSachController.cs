using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.Danhmuc.DmDoiTuongChinhSach
{
    public class DmDoiTuongChinhSachController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmDoiTuongChinhSachController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmDoiTuongChinhSach")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDoiTuongChinhSach.ToList();

                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_doituongcs";
                    return View("Views/Admin/Manages/Danhmuc/DmDoiTuongChinhSach/Index.cshtml", model);
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

        [Route("DmDoiTuongChinhSach/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmDoiTuongChinhSach request)
        {
            var model = new Models.Admin.Manages.DanhMuc.DmDoiTuongChinhSach
            {
                MaDoiTuongChinhSach = request.MaDoiTuongChinhSach,
                TenDoiTuongChinhSach = request.TenDoiTuongChinhSach,
                MoTa = request.MoTa,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DmDoiTuongChinhSach.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "DmDoiTuongChinhSach");
        }

        [Route("DmDoiTuongChinhSach/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmDoiTuongChinhSach.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã quốc gia</b></label>";
                result += "<input type='text' id='MaDoiTuongChinhSach_Edit' name='MaDoiTuongChinhSach' value='" + model.MaDoiTuongChinhSach + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên quốc gia</b></label>";
                result += "<input type='text' id='TenDoiTuongChinhSach_Edit' name='TenDoiTuongChinhSach' value='" + model.TenDoiTuongChinhSach + "' class='form-control'/>";
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

        [Route("DmDoiTuongChinhSach/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmDoiTuongChinhSach request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDoiTuongChinhSach.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaDoiTuongChinhSach = request.MaDoiTuongChinhSach;
                        model.TenDoiTuongChinhSach = request.TenDoiTuongChinhSach;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmDoiTuongChinhSach.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DmDoiTuongChinhSach");
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

        [Route("DmDoiTuongChinhSach/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDoiTuongChinhSach.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmDoiTuongChinhSach.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmDoiTuongChinhSach");
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
