using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Helper;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.KeHoachThuThapTT
{
    public class KeHoachThuThapThongTinXetDuyetController : Controller
    {
        private readonly ApplicationDbContext _db;

        public KeHoachThuThapThongTinXetDuyetController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("XetDuyetKeHoachThuThapThongTin")]
        public IActionResult Index(int Nam, string Status)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    Nam = Nam == 0 ? DateTime.Now.Year : Nam;
                    Status = string.IsNullOrEmpty(Status) ? "CD" : Status;
                    var model = _db.KeHoachThuThapThongTin.Where(t => t.NgayLapKeHoach.Year == Nam && t.Status == Status && Status != "CC");

                    ViewData["Title"] = "Xét duyệt kế hoạch thu thập thông tin lao động";
                    ViewData["MenuLv1"] = "menu_kehoachthuthapthongtin";
                    ViewData["MenuLv2"] = "menu_kehoachthuthapthongtin_xetduyet";
                    ViewData["Nam"] = Nam;
                    ViewData["Status"] = Status;
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/KeHoachThuThapTT/XetDuyet/Index.cshtml", model);
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

        [HttpPost("XetDuyetKeHoachThuThapThongTin/TraLai")]
        public JsonResult TraLai(int Id, string LyDoTraLai)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id)!;
                if (model != null)
                {
                    model.Status = "BTL";
                    model.LyDoTraLai = LyDoTraLai;
                    _db.KeHoachThuThapThongTin.Update(model);
                    _db.SaveChanges();
                }
                var data = new { status = "success", message = "Cập nhật thành công" };
                return Json(data);
            }
            else
            {
                var data = new { status = "error", message = "Bạn kêt thúc phiên đăng nhập! Đăng nhập lại để tiếp tục công việc" };
                return Json(data);
            }
        }

        [HttpPost("XetDuyetKeHoachThuThapThongTin/SetDuyet")]
        public JsonResult SetDuyet(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id)!;
                if (model != null)
                {
                    string result = "<div class='row' id='frm_xetduyet'>";
                    result += "<input hidden id='id_duyet' name='id_duyet' value='" + model.Id + "' />";
                    result += "<div class='col-xl-12'>";
                    result += "<div class='form-group fv-plugins-icon-container'>";
                    result += "<label> Kế hoạch:</label>";
                    result += "<label class='form-control''>" + model.KeHoach + "</label>";
                    result += "</div>";
                    result += "</div>";

                    result += "<div class='col-xl-6'>";
                    result += "<div class='form-group fv-plugins-icon-container'>";
                    result += "<label>Số Kế hoạch:</label>";
                    result += "<input type='text' class='form-control' id='sokehoach_duyet' name='sokehoach_duyet' value='" + model.SoKeHoach + "'/>";
                    result += "</div>";
                    result += "</div>";

                    result += "<div class='col-xl-6'>";
                    result += "<div class='form-group fv-plugins-icon-container'>";
                    result += "<label>Ngày ký kế hoạch:</label>";
                    result += "<input type='date' class='form-control' id='ngaykykehoach_duyet' name='ngaykykehoach_duyet' value='" + Funtions_Global.ConvertDateToFormView(DateTime.Now) + "'/>";
                    result += "</div>";
                    result += "</div>";

                    //result += "<div class='col-xl-6'>";
                    //result += "<div class='form-group fv-plugins-icon-container'>";
                    //result += "<label>Tên đọn vị:</label>";
                    //result += "<input type='date' class='form-control' id='tendonviky_duyet' name='tendonviky_duyet' value='" + Funtions_Global.GetSsAdmin(HttpContext.Session, "TenDonViBc") + "'/>";
                    //result += "</div>";
                    //result += "</div>";

                    //result += "<div class='col-xl-6'>";
                    //result += "<div class='form-group fv-plugins-icon-container'>";
                    //result += "<label>Địa danh:</label>";
                    //result += "<input type='date' class='form-control' id='diadanh_duyet' name='diadanh_duyet' value='" + Funtions_Global.GetSsAdmin(HttpContext.Session, "DiaDanh") + "'/>";
                    //result += "</div>";
                    //result += "</div>";

                    //result += "<div class='col-xl-6'>";
                    //result += "<div class='form-group fv-plugins-icon-container'>";
                    //result += "<label>Chức danh ký:</label>";
                    //result += "<input type='date' class='form-control' id='chucdanhky_duyet' name='chucdanhky_duyet' value='" + Funtions_Global.GetSsAdmin(HttpContext.Session, "ChucDanhNguoiKyBc") + "'/>";
                    //result += "</div>";
                    //result += "</div>";

                    //result += "<div class='col-xl-6'>";
                    //result += "<div class='form-group fv-plugins-icon-container'>";
                    //result += "<label>Họ và tên người ký:</label>";
                    //result += "<input type='date' class='form-control' id='hovatennguoiky_duyet' name='hovatennguoiky_duyet' value='" + Funtions_Global.GetSsAdmin(HttpContext.Session, "HoTenNguoiKyBc") + "'/>";
                    //result += "</div>";
                    //result += "</div>";

                    result += "</div>";

                    var data = new { status = "success", message = result };
                    return Json(data);
                }
                else
                {
                    var data = new { status = "error", message = "Không tìm thấy thông tin" };
                    return Json(data);
                }

            }
            else
            {
                var data = new { status = "error", message = "Bạn kêt thúc phiên đăng nhập! Đăng nhập lại để tiếp tục công việc" };
                return Json(data);
            }
        }


        [HttpPost("XetDuyetKeHoachThuThapThongTin/Duyet")]
        public JsonResult Duyet(int Id, string SoKeHoach, DateTime NgayKyKeHoach)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id)!;
                if (model != null)
                {
                    model.Status = "DD";
                    model.SoKeHoach = SoKeHoach;
                    model.NgayKyKeHoach = NgayKyKeHoach;
                    _db.KeHoachThuThapThongTin.Update(model);
                    _db.SaveChanges();
                    var data = new { status = "success", message = "Cập nhật thành công" };
                    return Json(data);
                }
                else
                {
                    var data = new { status = "error", message = "Không thể cập nhật" };
                    return Json(data);
                }

            }
            else
            {
                var data = new { status = "error", message = "Bạn kêt thúc phiên đăng nhập! Đăng nhập lại để tiếp tục công việc" };
                return Json(data);
            }
        }

        [HttpPost("XetDuyetKeHoachThuThapThongTin/HuyDuyet")]
        public JsonResult HuyDuyet(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.KeHoachThuThapThongTin.FirstOrDefault(t => t.Id == Id)!;
                if (model != null)
                {
                    model.Status = "CD";
                    _db.KeHoachThuThapThongTin.Update(model);
                    _db.SaveChanges();
                    var data = new { status = "success", message = "Cập nhật thành công" };
                    return Json(data);
                }
                else
                {
                    var data = new { status = "error", message = "Không thể cập nhật" };
                    return Json(data);
                }
            }
            else
            {
                var data = new { status = "error", message = "Bạn kêt thúc phiên đăng nhập! Đăng nhập lại để tiếp tục công việc" };
                return Json(data);
            }
        }
    }
}
