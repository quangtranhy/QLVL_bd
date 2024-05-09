
using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Danhmuc.Danhmuc.DmNgheDaoTao
{
    public class DmNgheDaoTaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmNgheDaoTaoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("DmNgheDaoTao")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmNgheDaoTao.ToList();
                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_nganhhoc";
                    return View("Views/Admin/Manages/Danhmuc/DmNgheDaoTao/Index.cshtml", model);
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

        [Route("DmNgheDaoTao/Store")]
        [HttpPost]
        public IActionResult Store(Models.Admin.Manages.DanhMuc.DmNgheDaoTao request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Models.Admin.Manages.DanhMuc.DmNgheDaoTao
                    {
                        MaNgheDaoTao = request.MaNgheDaoTao,
                        TenNgheDaoTao = request.TenNgheDaoTao,
                        MoTa = request.MoTa,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.DmNgheDaoTao.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "DmNgheDaoTao");
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

        [Route("DmNgheDaoTao/Edit")]
        [HttpPost]
        public JsonResult Edit(int Id)
        {
            var model = _db.DmNgheDaoTao.FirstOrDefault(p => p.Id == Id);

            if (model != null)
            {
                string result = "<div class='modal-body' id='edit_thongtin'>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mã nghề đào tạo</b></label>";
                result += "<input type='text' id='MaNgheDaoTao_Edit' name='MaNgheDaoTao' value='" + model.MaNgheDaoTao + "' class='form-control'/>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Tên nghề đào tạo</b></label>";
                result += "<input type='text' id='TenNgheDaoTao_Edit' name='TenNgheDaoTao' value='" + model.TenNgheDaoTao + "' class='form-control'/>";
                result += "</div>";
                result += "</div>";
                result += "</div>";

                result += "<div class='row'>";
                result += "<div class='col-xl-12'>";
                result += "<div class='form-group fv-plugins-icon-container'>";
                result += "<label><b>Mô tả</b></label>";
                result += "<textarea type='text' id='MoTa' name='MoTa' cols='12' rows='3' class='form-control'>" + model.MoTa + "</textarea>";
                result += "</div>";
                result += "</div>";
                result += "</div>";

                result += "<input hidden type='text' id='Id' name='Id' value='" + model.Id + "'/>";
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

        [Route("DmNgheDaoTao/Update")]
        [HttpPost]
        public IActionResult Update(Models.Admin.Manages.DanhMuc.DmNgheDaoTao request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmNgheDaoTao.FirstOrDefault(t => t.Id == request.Id);
                    if (model != null)
                    {
                        model.MaNgheDaoTao = request.MaNgheDaoTao;
                        model.TenNgheDaoTao = request.TenNgheDaoTao;
                        model.MoTa = request.MoTa;
                        model.Updated_at = DateTime.Now;
                        _db.DmNgheDaoTao.Update(model);
                        _db.SaveChanges();
                    }

                    return RedirectToAction("Index", "DmNgheDaoTao");
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

        [Route("DmNgheDaoTao/Delete")]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.DmNgheDaoTao.FirstOrDefault(t => t.Id == Id);
                    if (model != null)
                    {
                        _db.DmNgheDaoTao.Remove(model);
                        _db.SaveChanges();
                    }
                    return RedirectToAction("Index", "DmNgheDaoTao");
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
