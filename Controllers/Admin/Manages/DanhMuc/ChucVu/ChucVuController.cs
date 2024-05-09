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
using QLViecLam.Models.Admin;
using Azure.Core;
using QLViecLam.Models.Admin.Manages.DanhMuc;

namespace QLViecLam.Controllers.Admin.Danhmuc.ChucVu
{
    public class ChucVuController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ChucVuController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("ChucVu")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmChucVu;
                    var lastRecord = _db.DmChucVu.OrderByDescending(e => e.Id).FirstOrDefault();
                    ViewData["stt"] = lastRecord != null ? lastRecord.Stt : 1;

                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_chucvi";
                    return View("Views/Admin/Manages/Danhmuc/ChucVu/Index.cshtml", model);
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
        [Route("ChucVu/Store")]
        [HttpPost]
        public IActionResult Store(string tencv_create,string mota_create,int stt_create)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new DmChucVu
                    {
                        TenCv = tencv_create,
                        MoTa = mota_create,
                        Stt = stt_create.ToString(),
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmChucVu.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "ChucVu");
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
        [Route("ChucVu/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmChucVu.FirstOrDefault(p => p.Id == id);

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
                result += "<label><b>Tên chức vụ</b></label>";
                result += "<input type='text' id='tencv_edit' name='tencv_edit' value='" + model.TenCv + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả</b></label>";
                result += "<textarea type='text' id='mota_edit' name='mota_edit' cols='12' rows='3' class='form-control'>" + model.MoTa + "</textarea>";
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
        [Route("ChucVu/Update")]
        [HttpPost]
        public IActionResult Update(string tencv_edit, string mota_edit,int id_edit,int stt_edit)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmChucVu.FirstOrDefault(t => t.Id == id_edit);
                    if (model != null)
                    {
                        model.TenCv = tencv_edit;
                        model.MoTa = mota_edit;
                        model.Stt = stt_edit.ToString();
                        model.Updated_at = DateTime.Now;
                        _db.DmChucVu.Update(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "ChucVu");
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
        [Route("ChucVu/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmChucVu.FirstOrDefault(t => t.Id == id_delete);
                    if (model != null)
                    {
                        _db.DmChucVu.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "ChucVu");
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
