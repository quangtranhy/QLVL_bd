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

namespace QLViecLam.Controllers.Admin.Danhmuc.HieuLucHDLD
{
    public class HieuLucHDLDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HieuLucHDLDController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("HieuLucHDLD")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiHieuLucHdld;
                    var lastRecord = _db.DmLoaiHieuLucHdld.OrderByDescending(e => e.Id).FirstOrDefault();

                    ViewData["stt"] = lastRecord != null ? lastRecord.Stt : 1;
                    return View("Views/Admin/Manages/Danhmuc/HieuLucHDLD/Index.cshtml", model);
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
        [Route("HieuLucHDLD/Store")]
        [HttpPost]
        public IActionResult Store( string tenlhl_create, string mota_create, string trangthai_create, int stt_create)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new DmLoaiHieuLucHdld
                    {
                        TenLhl = tenlhl_create,
                        Mota = mota_create,
                        Trangthai = trangthai_create,
                        Stt = stt_create,
                        MaDmLhl = DateTime.Now.ToString("yyMMddssmmHH"),
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmLoaiHieuLucHdld.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "HieuLucHDLD");
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
        [Route("HieuLucHDLD/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmLoaiHieuLucHdld.FirstOrDefault(p => p.Id == id);

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
                result += "<label><b>Tên loại, hợp động lao động</b></label>";
                result += "<input type='text' id='tenlhl_edit' name='tenlhl_edit' value='" + model.TenLhl +"' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả</b></label>";
                result += "<textarea type='text' id='mota_edit' name='mota_edit' cols='12' rows='3' class='form-control'>" + model.Mota + "</textarea>";
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
        [Route("HieuLucHDLD/Update")]
        [HttpPost]
        public IActionResult Update(string tenlhl_edit, string mota_edit, int id_edit, string trangthai_edit)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiHieuLucHdld.FirstOrDefault(t => t.Id == id_edit);
                    if (model != null)
                    {
                        model.TenLhl = tenlhl_edit;
                        model.Mota = mota_edit;
                        model.Stt = id_edit;
                        model.Trangthai = trangthai_edit;
                        model.Updated_at = DateTime.Now;
                        _db.DmLoaiHieuLucHdld.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "HieuLucHDLD");
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
        [Route("HieuLucHDLD/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiHieuLucHdld.FirstOrDefault(t => t.Id == id_delete);
                    if (model != null)
                    {
                        _db.DmLoaiHieuLucHdld.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "HieuLucHDLD");
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
