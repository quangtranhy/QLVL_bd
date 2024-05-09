using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan
{
    public class RuiRoLamViecController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RuiRoLamViecController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("RuiRoLamViec")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.RuiRoLamViec;
                    var lastRecord = _db.RuiRoLamViec.OrderByDescending(e => e.Id).FirstOrDefault();

                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_ruiro_phuongtien_dieukien";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/RuiRoLamViec/Index.cshtml", model);
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
        [Route("RuiRoLamViec/Store")]
        [HttpPost]
        public IActionResult Store(string tenruiro_create, string capdo_create, string ghichu_create)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new RuiRoLamViec
                    {
                        TenRuiro = tenruiro_create,
                        CapDo = capdo_create,
                        GhiChu = ghichu_create,
                        MaRuiro = DateTime.Now.ToString("yyMMddssmmHH"),
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.RuiRoLamViec.Add(model);
                    _db.SaveChanges();
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_ruiro_phuongtien_dieukien";
                    return RedirectToAction("Index", "RuiRoLamViec");
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
        [Route("RuiRoLamViec/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.RuiRoLamViec.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chế độ chính sách</b></label>";
                result += "<input type='text' id='tenruiro_edit' name='tenruiro_edit' value='" + model.TenRuiro + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";

                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Cấp độ</b></label>";
                result += "<input type='text' id='capdo_edit' name='capdo_edit' value='" + model.CapDo + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Ghi chú</b></label>";
                result += "<textarea type='text' id='ghichu_edit' name='ghichu_edit' cols='12' rows='3' class='form-control'>" + model.GhiChu + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "</div>";

                result += "<input hidden type='text' id='id_edit' name='id_edit' value='" + model.Id + "'/>";
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
        [Route("RuiRoLamViec/Update")]
        [HttpPost]
        public IActionResult Update(string tenruiro_edit, string capdo_edit, string ghichu_edit, int id_edit)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.RuiRoLamViec.FirstOrDefault(t => t.Id == id_edit);
                    if (model != null)
                    {
                        model.TenRuiro = tenruiro_edit;
                        model.CapDo = capdo_edit;
                        model.GhiChu = ghichu_edit;
                        model.Updated_at = DateTime.Now;
                        _db.RuiRoLamViec.Update(model);
                        _db.SaveChanges();
                    }
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_ruiro_phuongtien_dieukien";
                    return RedirectToAction("Index", "RuiRoLamViec");
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
        [Route("RuiRoLamViec/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.RuiRoLamViec.FirstOrDefault(t => t.Id == id_delete);
                    if (model != null)
                    {
                        _db.RuiRoLamViec.Remove(model);
                        _db.SaveChanges();
                    }
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_ruiro_phuongtien_dieukien";
                    return RedirectToAction("Index", "RuiRoLamViec");
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
