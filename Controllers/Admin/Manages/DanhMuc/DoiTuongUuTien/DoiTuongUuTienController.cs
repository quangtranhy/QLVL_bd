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

namespace QLViecLam.Controllers.Admin.Danhmuc.DoiTuongUuTien
{
    public class DoiTuongUuTienController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DoiTuongUuTienController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DoiTuongUuTien")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDoiTuongUuTien;
                    return View("Views/Admin/Manages/Danhmuc/DoiTuongUuTien/Index.cshtml", model);
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
        [Route("DoiTuongUuTien/Store")]
        [HttpPost]
        public IActionResult Store(string tendoituong_create)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new DmDoiTuongUuTien
                    {
                        TenDoiTuong = tendoituong_create,
                        MaDmDt = DateTime.Now.ToString("yyMMddssmmHH"),
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmDoiTuongUuTien.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DoiTuongUuTien");
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
        [Route("DoiTuongUuTien/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmDoiTuongUuTien.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên chức vụ</b></label>";
                result += "<input type='text' id='tencv_edit' name='tencv_edit' value='" + model.TenDoiTuong + "' class='form-control' />";
                result += "</ div > ";
                result += " </ div > ";
                result += " </ div > ";

                result += "<input hidden type='text' id='id_edit' name='id_edit' value='" + model.Id + "' />";
                result += " </ div > ";

                var data = new { status = "success", message = result };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Không tìm thấy thông tin cần chỉnh sửa!!!" };
                return Json(data);
            }
        }
        [Route("DoiTuongUuTien/Update")]
        [HttpPost]
        public IActionResult Update(string tencv_edit, int id_edit)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDoiTuongUuTien.FirstOrDefault(t => t.Id == id_edit);
                    if (model != null)
                    {
                        model.TenDoiTuong = tencv_edit;
                        model.Updated_at = DateTime.Now;
                        _db.DmDoiTuongUuTien.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DoiTuongUuTien");
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
        [Route("DoiTuongUuTien/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDoiTuongUuTien.FirstOrDefault(t => t.Id == id_delete);
                    if (model != null)
                    {
                        _db.DmDoiTuongUuTien.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DoiTuongUuTien");
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
