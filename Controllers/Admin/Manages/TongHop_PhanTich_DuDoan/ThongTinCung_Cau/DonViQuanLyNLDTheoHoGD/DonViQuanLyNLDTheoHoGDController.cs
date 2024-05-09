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
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;
using QLViecLam.Models.Admin.Systems;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.ThongTinCung_Cau.DonViQuanLyNLDTheoHoGD
{
    public class DonViQuanLyNLDTheoHoGDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DonViQuanLyNLDTheoHoGDController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DonViQuanLyNLDTheoHoGD")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var models = from dv in _db.DmDonvi
                                 join dmhc in _db.DmHanhChinh on dv.MaDiaBan equals dmhc.MaQuocGia
                                 select new DmDonvi
                                 {
                                     Id = dv.Id,
                                     TenDv = dv.TenDv,
                                     MaDonVi = dv.MaDonVi,
                                     KhuVucHanhChinh = dmhc.Name,
                                     PhanLoaiTaiKhoan = dv.PhanLoaiTaiKhoan,
                                 };
                    ViewData["DonViChuQuan"] = _db.DmDonvi;
                    ViewData["DmHanhChinh"] = _db.DmHanhChinh;
                    ViewData["Title"] = "Đơn vị quản lý người lao động theo hộ gia đình";

                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_DonViQuanLyNLDTheoHoGD";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/DonViQuanLyNLDTheoHoGD/Index.cshtml", models);
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
        [Route("DonViQuanLyNLDTheoHoGD/Store")]
        [HttpPost]
        public IActionResult Store(string madv_create, string tendv_create, string tendvhienthi_create, string email_create, string madvcq_create, string madiaban_create)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new DmDonvi
                    {
                        MaDonVi = madv_create,
                        TenDv = tendv_create,
                        TenDvHienThi = tendvhienthi_create,
                        Email = email_create,
                        MaDvcq = madvcq_create,
                        MaDiaBan = madiaban_create,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmDonvi.Add(model);
                    _db.SaveChanges();
                    ViewData["Title"] = "Đơn vị quản lý người lao động theo hộ gia đình";
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_DonViQuanLyNLDTheoHoGD";
                    return RedirectToAction("Index", "DonViQuanLyNLDTheoHoGD");
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
        [Route("DonViQuanLyNLDTheoHoGD/Edit")]
        [HttpPost]
        public JsonResult Edit(int id)
        {
            var model = _db.DmDonvi.FirstOrDefault(p => p.Id == id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row text-left'>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã đơn vị:</b></label>";
                result += "<input type='number' id='madv_edit' name='madv_edit' value='" + model.MaDonVi + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên đơn vị:</b></label>";
                result += "<input type='number' id='tendv_edit' name='tendv_edit' value='" + model.TenDv + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên đơn vị hiển thị báo cáo:</b></label>";
                result += "<input type='number' id='tendvhienthi_edit' name='tendvhienthi_edit' value='" + model.TenDvHienThi + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Email</b></label>";
                result += "<input type='number' id='email_edit' name='email_edit' value='" + model.Email + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên đơn vị cấp trên:</b></label>";
                result += "<select type='text; id='madvcq_edit' name='madvcq_edit' class='form-control'>";

                foreach (var item in _db.DmDonvi)
                {
                    result += "<option value='" + item.MaDonVi + "'";
                    if (item.MaDonVi == model.MaDvcq)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.TenDv + "</option>";
                }
                result += "</div>";
                result += "</div>";
                result += "<div class='col-xl-6'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Khu vực hành chính:</b></label>";
                result += "<select type='text; id='madiaban_edit' name='madiaban_edit' class='form-control'>";

                foreach (var item in _db.DmHanhChinh)
                {
                    result += "<option value='" + item.MaQuocGia + "'";
                    if (item.MaQuocGia == model.MaDiaBan)
                    {
                        result += " selected='selected'";
                    }
                    result += ">" + item.Name + "</option>";
                }
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

        [Route("DonViQuanLyNLDTheoHoGD/Update")]
        [HttpPost]
        public IActionResult Update(string madv_edit, string tendv_edit, string tendvhienthi_edit, int id_edit, string email_edit, string madvcq_edit, string madiaban_edit)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDonvi.FirstOrDefault(t => t.Id == id_edit);
                    if (model != null)
                    {
                        model.MaDonVi = madv_edit;
                        model.TenDv = tendv_edit;
                        model.TenDvHienThi = tendvhienthi_edit;
                        model.Email = email_edit;
                        model.MaDvcq = madvcq_edit;
                        model.MaDiaBan = madiaban_edit;
                        model.Updated_at = DateTime.Now;
                        _db.DmDonvi.Update(model);
                        _db.SaveChanges();
                    }
                    ViewData["Title"] = "Đơn vị quản lý người lao động theo hộ gia đình";
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_DonViQuanLyNLDTheoHoGD";
                    return RedirectToAction("Index", "DonViQuanLyNLDTheoHoGD");
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
        [Route("DonViQuanLyNLDTheoHoGD/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmDonvi.FirstOrDefault(t => t.Id == id_delete);
                    if (model != null)
                    {
                        _db.DmDonvi.Remove(model);
                        _db.SaveChanges();
                    }
                    ViewData["Title"] = "Đơn vị quản lý người lao động theo hộ gia đình";
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_DonViQuanLyNLDTheoHoGD";
                    return RedirectToAction("Index", "DonViQuanLyNLDTheoHoGD");
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
