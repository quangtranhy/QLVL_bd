using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan
{
    public class DieuKienLamViecController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DieuKienLamViecController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("DieuKienLamViec")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.DieuKienLamViec;
            var lastRecord = _db.DieuKienLamViec.OrderByDescending(e => e.Id).FirstOrDefault();

            ViewData["MenuLv1"] = "menu_capnhatcungcau";
            ViewData["MenuLv2"] = "menu_capnhatcungcau_ruiro_phuongtien_dieukien";
            ViewData["MenuLv3"] = "menu_capnhatcungcau_dieukien";
            return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/DieuKienLamViec/Index.cshtml", model);
        }
        [Route("DieuKienLamViec/Store")]
        [HttpPost]
        public IActionResult Store(string tendieukien_create,  string capdo_create,string ghichu_create)
        {
            var model = new DieuKienLamViec
            {
                TenDieuKien = tendieukien_create,
                CapDo = capdo_create,
                GhiChu = ghichu_create,
                MaDieuKien = DateTime.Now.ToString("yyMMddssmmHH"),
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DieuKienLamViec.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "DieuKienLamViec");
        }
        [Route("DieuKienLamViec/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DieuKienLamViec.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chế độ chính sách</b></label>";
                result += "<input type='text' id='tendieukien_edit' name='tendieukien_edit' value='" + model.TenDieuKien + "' class='form-control'/>";
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
        [Route("DieuKienLamViec/Update")]
        [HttpPost]
        public IActionResult Update(string tendieukien_edit, string capdo_edit,string ghichu_edit, int id_edit)
        {
            var model = _db.DieuKienLamViec.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                model.TenDieuKien = tendieukien_edit;
                model.CapDo = capdo_edit;
                model.GhiChu = ghichu_edit;
                model.Updated_at = DateTime.Now;
                _db.DieuKienLamViec.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "DieuKienLamViec");
        }
        [Route("DieuKienLamViec/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.DieuKienLamViec.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.DieuKienLamViec.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "DieuKienLamViec");
        }
    }
}
