using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.DmTrinhDoNgoaiNgu
{
    public class DmTrinhDoNgoaiNguController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmTrinhDoNgoaiNguController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmTrinhDoNgoaiNgu")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoNgoaiNgu.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_TrinhDoNgoaiNgu";
                    return View("Views/Admin/Manages/Danhmuc/DmTrinhDoNgoaiNgu/Index.cshtml", model);
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

        [Route("DmTrinhDoNgoaiNgu/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmTrinhDoNgoaiNgu request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmTrinhDoNgoaiNgu
                    {
                        MaTrinhDoNgoaiNgu = request.MaTrinhDoNgoaiNgu,
                        TenTrinhDoNgoaiNgu = request.TenTrinhDoNgoaiNgu,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmTrinhDoNgoaiNgu.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmTrinhDoNgoaiNgu");
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

        [Route("DmTrinhDoNgoaiNgu/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmTrinhDoNgoaiNgu.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã trình độ ngoại ngữ</b></label>";
                result += "<input type='text' id='MaTrinhDoNgoaiNgu_Edit' name='MaTrinhDoNgoaiNgu' value='" + model.MaTrinhDoNgoaiNgu + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên trình độ ngoại ngữ</b></label>";
                result += "<input type='text' id='TenTrinhDoNgoaiNgu_Edit' name='TenTrinhDoNgoaiNgu' value='" + model.TenTrinhDoNgoaiNgu + "' class='form-control'/>";
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

        [Route("DmTrinhDoNgoaiNgu/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmTrinhDoNgoaiNgu request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoNgoaiNgu.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaTrinhDoNgoaiNgu = request.MaTrinhDoNgoaiNgu;
                        model.TenTrinhDoNgoaiNgu = request.TenTrinhDoNgoaiNgu;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmTrinhDoNgoaiNgu.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrinhDoNgoaiNgu");
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

        [Route("DmTrinhDoNgoaiNgu/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmTrinhDoNgoaiNgu.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmTrinhDoNgoaiNgu.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmTrinhDoNgoaiNgu");
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
