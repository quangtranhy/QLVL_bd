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

namespace QLViecLam.Controllers.Admin.Danhmuc.TinhTrangThamGiaHDKT
{
    public class TinhTrangThamGiaHDKTCtController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TinhTrangThamGiaHDKTCtController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("TinhTrangThamGiaHDKTCt")]
        public IActionResult Index(string madmtqkt)
        {
            var data = _db.DmTinhTrangThamGiaHdktCt.Where(x => x.MaNhom == madmtqkt);
            var models = new List<DmTinhTrangThamGiaHdktCt>();
            foreach (var item in data)
            {
                var cout = _db.DmTinhTrangThamGiaHdktCt2.Where(x => x.MaNhom2 == item.MaDmTgktCt).Count();
                models.Add(new DmTinhTrangThamGiaHdktCt
                {
                    Id = item.Id,
                    TenTgktCt = item.TenTgktCt,
                    MaDmTgktCt = item.MaDmTgktCt,
                    MaNhom = item.MaNhom,
                    MoTa = item.MoTa,
                    Trangthai = item.Trangthai,
                    CoutCt = cout,
                });
            }
            ViewData["Title"] = "Thông tin danh mục người có việc làm";
            ViewData["madmtqkt"] = madmtqkt;

            return View("Views/Admin/Manages/Danhmuc/TinhTrangThamGiaHDKTCt/Index.cshtml", models);
        }
        [Route("TinhTrangThamGiaHDKTCt/Store")]
        [HttpPost]
        public IActionResult Store(string tentgktct_create, string mota_create, string trangthai_create, int stt_create,string manhom_create)
        {
            var model = new DmTinhTrangThamGiaHdktCt
            {
                TenTgktCt = tentgktct_create,
                MoTa = mota_create,
                Trangthai = trangthai_create,
                MaNhom = manhom_create,
                Stt = stt_create,
                MaDmTgktCt = DateTime.Now.ToString("yyMMddssmmHH"),
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.DmTinhTrangThamGiaHdktCt.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "TinhTrangThamGiaHDKTCt");
        }
        [Route("TinhTrangThamGiaHDKTCt/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmTinhTrangThamGiaHdktCt.FirstOrDefault(p => p.Id == id);

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
                result += "<label><b>Tên phân loại</b></label>";
                result += "<input type='text' id='tentgktct_edit' name='tentgktct_edit' value='" + model.TenTgktCt + "' class='form-control'/>";
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
        [Route("TinhTrangThamGiaHDKTCt/Update")]
        [HttpPost]
        public IActionResult Update(string tentgktct_edit, string mota_edit, int id_edit, string trangthai_edit)
        {
            var model = _db.DmTinhTrangThamGiaHdktCt.FirstOrDefault(t => t.Id == id_edit);
            if (model != null)
            {
                model.TenTgktCt = tentgktct_edit;
                model.MoTa = mota_edit;
                model.Stt = id_edit;
                model.Trangthai = trangthai_edit;
                model.Updated_at = DateTime.Now;
                _db.DmTinhTrangThamGiaHdktCt.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "TinhTrangThamGiaHDKTCt");
        }
        [Route("TinhTrangThamGiaHDKTCt/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.DmTinhTrangThamGiaHdktCt.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.DmTinhTrangThamGiaHdktCt.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "TinhTrangThamGiaHDKTCt");
        }
    }
}
