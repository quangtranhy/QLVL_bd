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

namespace QLViecLam.Controllers.Admin.Danhmuc.LoaiHinhHDKT
{
    public class LoaiHinhHDKTController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoaiHinhHDKTController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("LoaiHinhHDKT")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiHinhHdkt;
                    var lastRecord = _db.DmLoaiHinhHdkt.OrderByDescending(e => e.Id).FirstOrDefault();
                    ViewData["stt"] = lastRecord != null ? lastRecord.Stt : 1;
                    return View("Views/Admin/Manages/Danhmuc/LoaiHinhHDKT/Index.cshtml", model);
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
        [Route("LoaiHinhHDKT/Store")]
        [HttpPost]
        public IActionResult Store( string tenlhkt_create, string mota_create, string trangthai_create, int stt_create)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new DmLoaiHinhHdkt
                    {
                        TenLhkt = tenlhkt_create,
                        MoTa = mota_create,
                        Trangthai = trangthai_create,
                        Stt = stt_create,
                        MaDmLhkt = DateTime.Now.ToString("yyMMddssmmHH"),
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now,
                    };
                    _db.DmLoaiHinhHdkt.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "LoaiHinhHDKT");
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
        [Route("LoaiHinhHDKT/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmLoaiHinhHdkt.FirstOrDefault(p => p.Id == id);

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
                result += "<label><b>Tên loại hình kinh tế</b></label>";
                result += "<input type='text' id='tenlhkt_edit' name='tenlhkt_edit' value='" + model.TenLhkt + "' class='form-control'/>";
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
        [Route("LoaiHinhHDKT/Update")]
        [HttpPost]
        public IActionResult Update(string tenlhkt_edit, string mota_edit, int id_edit, string trangthai_edit)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiHinhHdkt.FirstOrDefault(t => t.Id == id_edit);
                    if (model != null)
                    {
                        model.TenLhkt = tenlhkt_edit;
                        model.MoTa = mota_edit;
                        model.Stt = id_edit;
                        model.Trangthai = trangthai_edit;
                        model.updated_at = DateTime.Now;
                        _db.DmLoaiHinhHdkt.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "LoaiHinhHDKT");
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
        [Route("LoaiHinhHDKT/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmLoaiHinhHdkt.FirstOrDefault(t => t.Id == id_delete);
                    if (model != null)
                    {
                        _db.DmLoaiHinhHdkt.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "LoaiHinhHDKT");
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
