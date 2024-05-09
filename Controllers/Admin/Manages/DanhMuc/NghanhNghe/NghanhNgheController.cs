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

namespace QLViecLam.Controllers.Admin.Danhmuc.NghanhNghe
{
    public class NghanhNgheController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NghanhNgheController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("NghanhNghe")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.DmNganhNghe;
            var lastRecord = _db.DmNganhNghe.OrderByDescending(e => e.Id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.Stt : 1;
            return View("Views/Admin/Manages/Danhmuc/NghanhNghe/Index.cshtml", model);
        }
        [Route("NghanhNghe/Store")]
        [HttpPost]
        public IActionResult Store(string madm_create, string tendm_create, int stt_create)
        {
            var model = new DmNganhNghe
            {
                MaDm = madm_create,
                TenDm = tendm_create,
                Stt = stt_create,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DmNganhNghe.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "NghanhNghe");
        }
        [Route("NghanhNghe/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmNganhNghe.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Số thứ tự</b></label>";
                result += "<input type='number' id='stt_edit' name='stt_edit' value='" + model.Stt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã nghành nghề</b></label>";
                result += "<input type='text' id='madm_edit' name='madm_edit' value='" + model.MaDm + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên nghành nghề</b></label>";
                result += "<input type='text' id='tendm_edit' name='tendm_edit' value='" + model.TenDm + "' class='form-control'/>";
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
        [Route("NghanhNghe/Update")]
        [HttpPost]
        public IActionResult Update(string madm_edit, string tendm_edit, int id_edit, int stt_edit)
        {
            var model = _db.DmNganhNghe.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                model.MaDm = madm_edit;
                model.TenDm = tendm_edit;
                model.Stt = stt_edit;
                model.Updated_at = DateTime.Now;
                _db.DmNganhNghe.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "NghanhNghe");
        }
        [Route("NghanhNghe/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.DmNganhNghe.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.DmNganhNghe.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "NghanhNghe");
        }
    }
}
