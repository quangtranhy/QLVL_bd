using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.DanhMuc;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan
{
    public class CheDoChinhSachController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CheDoChinhSachController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("CheDoChinhSach")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.CheDoChinhSach;
            var lastRecord = _db.CheDoChinhSach.OrderByDescending(e => e.Id).FirstOrDefault();

            ViewData["MenuLv1"] = "menu_capnhatcungcau";
            ViewData["MenuLv2"] = "menu_capnhatcungcau_chedochinhsach";
            return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/CheDoChinhSach/Index.cshtml", model);
        }
        [Route("CheDoChinhSach/Store")]
        [HttpPost]
        public IActionResult Store()
        {
            var model = new CheDoChinhSach
            {
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.CheDoChinhSach.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "CheDoChinhSach");
        }
        /*[Route("CheDoChinhSach/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.CheDoChinhSach.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chế độ chính sách</b></label>";
                result += "<input type='text' id='tenchedo_edit' name='tenchedo_edit' value='" + model.TenCheDo + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Năm</b></label>";
                result += "<input type='text' id='nam_edit' name='nam_edit' value='" + model.Nam + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Bảo hiểm xã hội</b></label>";
                result += "<input type='text' id='bhxh_edit' name='bhxh_edit' value='" + model.Bhxh + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Bảo hiểm y tế</b></label>";
                result += "<input type='text' id='bhyt_edit' name='bhyt_edit' value='" + model.Bhyt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tiền lương</b></label>";
                result += "<input type='text' id='tienluong_edit' name='tienluong_edit' value='" + model.TienLuong + "' class='form-control'/>";
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
        }*/
        [Route("CheDoChinhSach/Update")]
        [HttpPost]
        public IActionResult Update()
        {
            /*var model = _db.CheDoChinhSach.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                model.Updated_at = DateTime.Now;
                _db.CheDoChinhSach.Update(model);
                _db.SaveChanges();
            }*/

            return RedirectToAction("Index", "CheDoChinhSach");
        }
        [Route("CheDoChinhSach/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.CheDoChinhSach.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.CheDoChinhSach.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "CheDoChinhSach");
        }
    }
}
