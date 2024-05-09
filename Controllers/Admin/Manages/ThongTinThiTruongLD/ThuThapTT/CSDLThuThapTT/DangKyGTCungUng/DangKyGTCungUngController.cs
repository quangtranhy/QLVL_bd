using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Helper;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT.DangKyGTCungUng
{
    public class DangKyGTCungUngController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DangKyGTCungUngController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("DangKyGTCungUng")]
        [HttpGet]
        public IActionResult Index(string huyen, string xa)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    if (huyen == null || huyen == "")
                    {
                        huyen = _db.DmHanhChinh.Where(x => x.CapDo == "H").FirstOrDefault()!.Name!;
                    }

                    var parent = _db.DmHanhChinh.Where(x => x.CapDo == "H" && x.Name == huyen).FirstOrDefault()!.MaQuocGia;

                    if (string.IsNullOrEmpty(xa))
                    {
                        xa = _db.DmHanhChinh.Where(x => x.CapDo == "X" && x.Parent == parent).FirstOrDefault()!.Name!;
                    }
                    //doc ra cac doanh nghiep co tin tuyn dung
                    var allCompany = _db.TuyenDung.GroupBy(x => x.User);
                    var company = new List<Company>();
                    foreach (var item in allCompany)
                    {
                        company.Add(_db.Company.FirstOrDefault(x => x.Id == item.Key)!);
                    }

                    var model = company.Where(x => x.Xa == xa);
                    ViewData["tenhuyen"] = huyen;
                    ViewData["tenxa"] = xa;
                    //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");
                    ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X" && t.Parent == parent);
                    ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_DangKyGTCungUng";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/DangKyGTCungUng/Index.cshtml", model);
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
        [Route("DangKyGTCungUng/TuyenDung")]
        [HttpGet]
        public IActionResult TuyenDung(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = (from td in _db.TuyenDung.Where(x => x.User == Id)
                                 join vt in _db.ViTriTuyenDung
                                 on td.Id equals vt.IdTuyenDung
                                 select new VM_TuyenDung
                                 {
                                     Id = vt.Id,
                                     NoiDung = td.NoiDung!,
                                     Name = vt.Name!,
                                     SoLuong = vt.Soluong,
                                     DaTuyen = td.DaTuyen,
                                     DaTuyenTutt = td.DaTuyenTutt,
                                     State = td.State,
                                     ThoiHan = td.ThoiHan
                                 });
                    var vttd = _db.ViTriTuyenDung.Where(x => x.State == "CXD");
                    if (vttd != null) { _db.ViTriTuyenDung.RemoveRange(vttd); }

                    _db.SaveChanges();

                    ViewData["doanhnghiep"] = _db.Company.Where(x => x.Id == Id).FirstOrDefault()!.Name;
                    ViewData["Id"] = Id;

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_DangKyGTCungUng";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/DangKyGTCungUng/TuyenDung.cshtml", model);
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
        [Route("DangKyGTCungUng/Print")]
        [HttpGet]
        public IActionResult Print(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var ViTriTuyenDung = _db.ViTriTuyenDung.FirstOrDefault(x => x.Id == Id);
                    var user = _db.TuyenDung.FirstOrDefault(x => x.Id == ViTriTuyenDung!.IdTuyenDung);
                    var doanhnghiep = _db.Company.FirstOrDefault(x => x.User == user!.User);

                    ViewData["name"] = doanhnghiep!.Name;
                    ViewData["address"] = doanhnghiep.Address;
                    ViewData["phone"] = doanhnghiep.Phone;
                    ViewData["fax"] = doanhnghiep.Fax;
                    ViewData["email"] = doanhnghiep.Email;
                    ViewData["dkkd"] = doanhnghiep.Dkkd;
                    ViewData["dmloaihinhhdkt"] = _db.DmLoaiHinhHdkt;

                    var nn = Helpers.NganhNgheKinhDoanh();
                    var tennn = "";
                    foreach (var n in nn)
                    {
                        if (n.MaNghanhNghe == doanhnghiep.NganhNghe)
                        {
                            tennn = n.TenNghanhNghe;
                            break;
                        }
                    }
                    ViewData["tennn"] = tennn;

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_DangKyGTCungUng";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/DangKyGTCungUng/DangKyGTCungUng_Print.cshtml");
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

        [Route("DangKyGTCungUng/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["idtuyendung"] = DateTime.Now.ToString("yyMMddssmmHH");

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_csdl";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_csdl_DangKyGTCungUng";
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/DangKyGTCungUng/Create.cshtml");
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
        [Route("DangKyGTCungUng/Store")]
        [HttpPost]
        public IActionResult Store(string name, string noidung, DateTime thoihan, string contact, string phonetd, string emailtd, string chucvutd, string yeucau, int soluong, int user, int idtuyendung)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new TuyenDung
                    {
                        NoiDung = noidung,
                        ThoiHan = thoihan,
                        Contact = contact,
                        PhoneTd = phonetd,
                        EmailTd = emailtd,
                        ChucvuTd = chucvutd,
                        YeuCau = yeucau,
                        User = user,
                        State = 0,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.TuyenDung.Add(model);
                    var vttd = _db.ViTriTuyenDung.Where(x => x.IdTuyenDung == idtuyendung);
                    if (vttd != null)
                    {
                        foreach (var item in vttd)
                        {
                            item.IdTuyenDung = _db.TuyenDung.OrderByDescending(x => x.Id).FirstOrDefault()!.Id;
                            item.State = "XD";
                        }
                    }
                    _db.ViTriTuyenDung.UpdateRange(vttd!);
                    _db.SaveChanges();
                    return RedirectToAction("TuyenDung", "DangKyGTCungUng", new { user });
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
