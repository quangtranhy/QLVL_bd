using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using QLViecLam.Data;
using System.Security.Cryptography;
using QLViecLam.Helper;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLViecLam.Models.Admin.Manages.DanhMuc;
using Azure.Core;

namespace QLViecLam.Controllers.Admin.Danhmuc.NguyenNhanThatNghiep
{
    public class NguyenNhanThatNghiepController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NguyenNhanThatNghiepController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("NguyenNhanThatNghiep")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.DmNguyenNhanThatNghiep;
            var lastRecord = _db.DmNguyenNhanThatNghiep.OrderByDescending(e => e.Id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.Stt : 1;
            return View("Views/Admin/Manages/Danhmuc/DmNguyenNhanThatNghiep/Index.cshtml", model);
        }
        [Route("NguyenNhanThatNghiep/Store")]
        [HttpPost]
        public IActionResult Store(string tennn_create, int stt_create)
        {
            var model = new DmNguyenNhanThatNghiep
            {
                TenNn = tennn_create,
                Stt = stt_create.ToString(),
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DmNguyenNhanThatNghiep.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "NguyenNhanThatNghiep");
        }
        [Route("NguyenNhanThatNghiep/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmNguyenNhanThatNghiep.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Số thứ tự</b></label>";
                result += "<input type='text' id='stt_edit' name='stt_edit' value='" + model.Stt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên nguyên nhân</b></label>";
                result += "<input type='text' id='tennn_edit' name='tennn_edit' value='" + model.TenNn + "' class='form-control'/>";
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
        [Route("NguyenNhanThatNghiep/Update")]
        [HttpPost]
        public IActionResult Update(string tennn_edit,  int id_edit)
        {
            var model = _db.DmNguyenNhanThatNghiep.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                model.TenNn = tennn_edit;
                model.Updated_at = DateTime.Now;
                _db.DmNguyenNhanThatNghiep.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "NguyenNhanThatNghiep");
        }
        [Route("NguyenNhanThatNghiep/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.DmNguyenNhanThatNghiep.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.DmNguyenNhanThatNghiep.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "NguyenNhanThatNghiep");
        }
    }
}
