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

namespace QLViecLam.Controllers.Admin.Danhmuc.TrinhDoCMKT
{
    public class TrinhDoCMKTController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TrinhDoCMKTController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("TrinhDoCMKT")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _db.DmTrinhDoKyThuat;
            var lastRecord = _db.DmTrinhDoKyThuat.OrderByDescending(e => e.Id).FirstOrDefault();
            ViewData["stt"] = lastRecord != null ? lastRecord.Stt : 1;

            ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
            ViewData["MenuLv2"] = "menu_quanlydanhmuc_cmkt";
            return View("Views/Admin/Manages/Danhmuc/TrinhDoCMKT/Index.cshtml", model);
        }
        [Route("TrinhDoCMKT/Store")]
        [HttpPost]
        public IActionResult Store(string tentdkt_create, string mota_create, string trangthai_create, int stt_create)
        {
            var model = new DmTrinhDoKyThuat
            {
                Tentdkt = tentdkt_create,
                MoTa = mota_create,
                Trangthai = trangthai_create,
                Stt = stt_create,
                MaDmTdkt = DateTime.Now.ToString("yyMMddssmmHH"),
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DmTrinhDoKyThuat.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "TrinhDoCMKT");
        }
        [Route("TrinhDoCMKT/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmTrinhDoKyThuat.FirstOrDefault(p => p.Id == id);

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
                result += "<label><b>Tên trình độ</b></label>";
                result += "<input type='text' id='tentdkt_edit' name='tentdkt_edit' value='" + model.Tentdkt + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả</b></label>";
                result += "<textarea type='text' id='mota_edit' name='mota_edit' cols='12' rows='3' class='form-control'>" + model.MoTa + "</textarea>";
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
        [Route("TrinhDoCMKT/Update")]
        [HttpPost]
        public IActionResult Update(string tentdkt_edit, string mota_edit, int id_edit, string trangthai_edit)
        {
            var model = _db.DmTrinhDoKyThuat.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                model.Tentdkt = tentdkt_edit;
                model.MoTa = mota_edit;
                model.Stt = id_edit;
                model.Trangthai = trangthai_edit;
                model.Updated_at = DateTime.Now;
                _db.DmTrinhDoKyThuat.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "TrinhDoCMKT");
        }
        [Route("TrinhDoCMKT/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.DmTrinhDoKyThuat.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.DmTrinhDoKyThuat.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "TrinhDoCMKT");
        }
    }
}
