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

namespace QLViecLam.Controllers.Admin.Danhmuc.TrinhDoGDPT
{
    public class TrinhDoGDPTController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TrinhDoGDPTController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("TrinhDoGDPT")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.DmTrinhDoGdpt;
            var lastRecord = _db.DmTrinhDoGdpt.OrderByDescending(e => e.Id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.Stt : 1;
            return View("Views/Admin/Manages/Danhmuc/TrinhDoGDPT/Index.cshtml", model);
        }
        [Route("TrinhDoGDPT/Store")]
        [HttpPost]
        public IActionResult Store( string tengdpt_create, string trangthai_create, int stt_create)
        {
            var model = new DmTrinhDoGdpt
            {
                TenGdpt = tengdpt_create,
                Trangthai = trangthai_create,
                Stt = stt_create.ToString(),
                MaDmGdpt = DateTime.Now.ToString("yyMMddssmmHH"),
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DmTrinhDoGdpt.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "TrinhDoGDPT");
        }
        [Route("TrinhDoGDPT/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmTrinhDoGdpt.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Số thứ tự</b></label>";
                result += "<input type='text' id='stt_edit' name='stt_edit' value='" + int.Parse(model.Stt) + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên trình độ GDPT cao nhất</b></label>";
                result += "<input type='text' id='tengdpt_edit' name='tengdpt_edit' value='" + model.TenGdpt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Trạng thái</b></label>";
                result += "<select class='form-control' id='trangthai_edit' name='trangthai_edit'>";
                if (model.Trangthai == "kh")
                {
                    result += "<option value='kh' selected>Kích hoạt</option>";
                    result += "<option value='kkh'>Không kích hoạt</option>";
                }
                else
                {
                    result += "<option value='kkh' selected>Không kích hoạt</option>";
                    result += "<option value='kh'>Kích hoạt</option>";
                }
                result += "</select>";
                result += "</div></div>";
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
        [Route("TrinhDoGDPT/Update")]
        [HttpPost]
        public IActionResult Update(string tengdpt_edit, string mota_edit, int id_edit,string trangthai_edit)
        {
            var model = _db.DmTrinhDoGdpt.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                model.TenGdpt = tengdpt_edit;
                model.Trangthai = trangthai_edit;
                model.Updated_at = DateTime.Now;
                _db.DmTrinhDoGdpt.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "TrinhDoGDPT");
        }
        [Route("TrinhDoGDPT/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.DmTrinhDoGdpt.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.DmTrinhDoGdpt.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "TrinhDoGDPT");
        }
    }
}
