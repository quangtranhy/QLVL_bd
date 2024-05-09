using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.Danhmuc.DmKhuCongNghiep
{
    public class DmKhuCongNghiepController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmKhuCongNghiepController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmKhuCongNghiep")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmKhuCongNghiep.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_khucn";
                    return View("Views/Admin/Manages/Danhmuc/DmKhuCongNghiep/Index.cshtml", model);
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

        [Route("DmKhuCongNghiep/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmKhuCongNghiep request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmKhuCongNghiep
                    {
                        MaKhuCongNghiep = request.MaKhuCongNghiep,
                        TenKhuCongNghiep = request.TenKhuCongNghiep,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmKhuCongNghiep.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmKhuCongNghiep");
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

        [Route("DmKhuCongNghiep/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmKhuCongNghiep.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã quốc gia</b></label>";
                result += "<input type='text' id='MaKhuCongNghiep_Edit' name='MaKhuCongNghiep' value='" + model.MaKhuCongNghiep + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên quốc gia</b></label>";
                result += "<input type='text' id='TenKhuCongNghiep_Edit' name='TenKhuCongNghiep' value='" + model.TenKhuCongNghiep + "' class='form-control'/>";
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

        [Route("DmKhuCongNghiep/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmKhuCongNghiep request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmKhuCongNghiep.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaKhuCongNghiep = request.MaKhuCongNghiep;
                        model.TenKhuCongNghiep = request.TenKhuCongNghiep;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmKhuCongNghiep.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DmKhuCongNghiep");
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

        [Route("DmKhuCongNghiep/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmKhuCongNghiep.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmKhuCongNghiep.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmKhuCongNghiep");
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
