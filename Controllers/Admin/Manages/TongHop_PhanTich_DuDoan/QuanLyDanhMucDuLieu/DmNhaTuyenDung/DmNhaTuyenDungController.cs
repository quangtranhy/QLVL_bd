using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.DanhMuc;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using System.Net;
using System.Runtime.CompilerServices;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.QuanLyDanhMucDuLieu.DmNhaTuyenDung
{
    public class DmNhaTuyenDungController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DmNhaTuyenDungController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("DmNhaTuyenDung")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var allCompany = _db.TuyenDung.GroupBy(x => x.User);
                    var company = new List<Company>();
                    foreach (var item in allCompany)
                    {
                        company.Add(_db.Company.FirstOrDefault(x => x.Id == item.Key)!);
                    }
                    ViewData["Tinh"] = _db.DmHanhChinh.Where(x => x.CapDo == "T");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(x => x.CapDo == "H");
                    ViewData["Xa"] = _db.DmHanhChinh.Where(x => x.CapDo == "X");

                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_DmNhaTuyenDung";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/QuanLyDanhMucDuLieu/DmNhaTuyenDung/Index.cshtml", company);
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
        [Route("DmNhaTuyenDung/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["Tinh"] = _db.DmHanhChinh.Where(x => x.CapDo == "T");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(x => x.CapDo == "H");
                    ViewData["Xa"] = _db.DmHanhChinh.Where(x => x.CapDo == "X");
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;
                    ViewData["DmNganhNghe"] = _db.DmNganhNghe;

                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_DmNhaTuyenDung";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/QuanLyDanhMucDuLieu/DmNhaTuyenDung/Create.cshtml");
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
        [Route("DmNhaTuyenDung/Store")]
        [HttpPost]
        public IActionResult Store(Company request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new Company
                    {
                        Name = request.Name,
                        MaSoDn = request.MaSoDn,
                        Dkkd = request.Dkkd,
                        Phone = request.Phone,
                        Fax = request.Fax,
                        Website = request.Website,
                        Email = request.Email,
                        Address = request.Address,
                        Huyen = request.Huyen,
                        Xa = request.Xa,
                        Tinh = "Quảng Bình",
                        KhuCn = request.KhuCn,
                        KhuVuc = request.KhuVuc,
                        LoaiHinh = request.LoaiHinh,
                        Public = request.Public,
                        Image = request.Image,
                        User = request.User,
                        NganhNghe = request.NganhNghe,
                        QuyMo = request.QuyMo,
                        Sld = request.Sld,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.Company.Add(model);
                    _db.SaveChanges();

                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_DmNhaTuyenDung";
                    return RedirectToAction("Index", "DmNhaTuyenDung");
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
        [Route("DmNhaTuyenDung/Edit")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.Company.FirstOrDefault(t => t.Id == Id);

                    
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/QuanLyDanhMucDuLieu/DmNhaTuyenDung/Edit.cshtml", model);
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
        [Route("DmNhaTuyenDung/Update")]
        [HttpPost]
        public IActionResult Update(Company request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.Company.FirstOrDefault(t => t.Id == request.Id);

                    model.Name = request.Name;
                    model.MaSoDn = request.MaSoDn;
                    model.Dkkd = request.Dkkd;
                    model.Phone = request.Phone;
                    model.Fax = request.Fax;
                    model.Website = request.Website;
                    model.Email = request.Email;
                    model.Address = request.Address;
                    model.Huyen = request.Huyen;
                    model.Xa = request.Xa;
                    model.Tinh = "Quảng Bình";
                    model.KhuCn = request.KhuCn;
                    model.KhuVuc = request.KhuVuc;
                    model.LoaiHinh = request.LoaiHinh;
                    model.Public = request.Public;
                    model.Image = request.Image;
                    model.User = request.User;
                    model.NganhNghe = request.NganhNghe;
                    model.QuyMo = request.QuyMo;
                    model.Sld = request.Sld;
                    model.Created_at = DateTime.Now;
                    model.Updated_at = DateTime.Now;
                    _db.Company.Update(model);
                    _db.SaveChanges();

                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_DmNhaTuyenDung";
                    return RedirectToAction("Index", "DmNhaTuyenDung");
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
        [Route("DmNhaTuyenDung/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.Company.FirstOrDefault(t => t.Id == id_delete);
                    _db.Company.Remove(model);
                    _db.SaveChanges();

                    ViewData["MenuLv1"] = "menu_quanlydanhmucdulieu";
                    ViewData["MenuLv2"] = "menu_quanlydanhmuc_DmNhaTuyenDung";
                    return RedirectToAction("Index", "DmNhaTuyenDung");
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
