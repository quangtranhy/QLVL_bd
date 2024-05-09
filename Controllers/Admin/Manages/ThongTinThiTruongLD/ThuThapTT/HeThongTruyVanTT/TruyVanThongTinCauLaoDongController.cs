using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.HeThongTruyVanTT;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.TruyVanThongTinCauLaoDong
{
    public class TruyVanThongTinCauLaoDongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TruyVanThongTinCauLaoDongController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("TruyVanThongTinCauLaoDong/VanTinKiemTraXacThucCauLD")]
        public IActionResult VanTinKiemTraXacThucCauLD(string huyen, string xa,string NganhNghe, Boolean TinhTrangXacThuc)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
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
                var model = _db.Company.Where(x => x.Xa == xa && x.TinhTrangXacThuc==TinhTrangXacThuc && x.NganhNghe==NganhNghe);
                ViewData["TinhTrangXacThuc"] = TinhTrangXacThuc;
                ViewData["NganhNghe"] = NganhNghe;
                ViewData["DmNganhNghe"] = _db.DmNganhNghe;
                ViewData["tenhuyen"] = huyen;
                ViewData["tenxa"] = xa;
                ViewData["cout"] = model.Count();
                //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");
                ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X" && t.Parent == parent);
                ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
                ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;

                ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cau";
                return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CauLaoDong/Index.cshtml", model);               
                
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }
        [Route("TruyVanThongTinCauLaoDong/Detail")]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = _db.Company.Where(x => x.Id == id).FirstOrDefault()!;
            var nguoilaodong = _db.NguoiLaoDong.Where(x => x.Company == model.Id);
            var thongtinkhac = new List<VM_Thongtin_DoanhNghiep>();
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Tổng số lao động(tổng/nữ)",
                Soluong = nguoilaodong.Count().ToString() + '/' + nguoilaodong.Where(x => x.GioiTinh == "Nữ").Count().ToString(),
            });

            ViewData["name"] = model!.Name;
            ViewData["model"] = model;
            ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0");
            ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");
            ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X");
           

            //doc ra thong tin nguoilaodong
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Số lao động ngoại tỉnh",
                Soluong = nguoilaodong.Where(x => x.Tinh != "Quảng Bình").Count().ToString(),
            });

            //Không có HĐLĐ
            var loaihdld = nguoilaodong.Where(x => x.LoaiHdld != "Không có HĐLĐ");
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Số lao động đã ký HĐLĐ (tổng/nữ)",
                Soluong = loaihdld.Count().ToString() + '/' + loaihdld.Where(x => x.GioiTinh == "Nữ").Count().ToString(),
            });
            //nước ngoài
            var nation = nguoilaodong.Where(x => x.Nation != "VN");
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Số lao động nước ngoài (tổng/nữ)",
                Soluong = nation.Count().ToString() + '/' + nation.Where(x => x.GioiTinh == "Nữ").Count().ToString(),
            });
            //tốt nghiệp phổ thông
            var trinhdogiaoduc = nguoilaodong.Where(x => x.TrinhDoGiaoDuc == "Tốt nghiệp THPT");
            thongtinkhac.Add(new VM_Thongtin_DoanhNghiep
            {
                Mota = "Số lao động đã tốt nghiệp phổ thông",
                Soluong = trinhdogiaoduc.Count().ToString(),
            });
            //luong
            var luong = new List<VM_Luong_NguoiLaoDong>();
            var average = nguoilaodong.Average(x => Convert.ToDouble(x.Luong));
            luong.Add(new VM_Luong_NguoiLaoDong
            {
                Mota = "Lương bình quân",
                Luong = average.ToString()
            });
            luong.Add(new VM_Luong_NguoiLaoDong
            {
                Mota = "Lương thấp nhất",
                Luong = nguoilaodong.Min(x => x.Luong),
            });
            luong.Add(new VM_Luong_NguoiLaoDong
            {
                Mota = "Lương cao nhất",
                Luong = nguoilaodong.Max(x => x.Luong),
            });
            ViewData["luong"] = luong;

            //doc ra so luong cac loai cmkt
            var trinhdocmkt = nguoilaodong
                .GroupBy(x => x.TrinhDoCmkt)
                .Select(group => new VM_Count_Chucnang
                {
                    Mota = group.Key,
                    Count = group.Count()
                });
            ViewData["trinhdocmkt"] = trinhdocmkt;

            //doc ra so luong cac loai linh vuc daotao
            var linhvucdaotao = nguoilaodong
                .GroupBy(x => x.LinhVucDaoTao)
                .Select(group => new VM_Count_Chucnang
                {
                    Mota = group.Key,
                    Count = group.Count()
                });
            ViewData["linhvucdaotao"] = linhvucdaotao;

            //doc ra so luong cua cac nghenghiep
            var nghenghiep = nguoilaodong
                .GroupBy(x => x.NgheNghiep)
                .Select(group => new VM_Count_Chucnang
                {
                    Mota = group.Key,
                    Count = group.Count()
                });
            ViewData["nghenghiep"] = nghenghiep;
            ViewData["thongtinkhac"] = thongtinkhac;

            ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
            ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
            ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cau";
            return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/HeThongTruyVanTT/CauLaoDong/Detail.cshtml", model);

        }
        [Route("TruyVanThongTinCauLaoDong/XacThuc")]
        [HttpGet]
        public IActionResult XacThuc(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.Company.Where(x => x.Id == Id).FirstOrDefault()!;
                    model.TinhTrangXacThuc = true;
                    _db.SaveChanges();

                    ViewData["MenuLv1"] = "menu_thuthapthongtinthitruong";
                    ViewData["MenuLv2"] = "menu_thuthapthongtinthitruong_truyvantt";
                    ViewData["MenuLv3"] = "menu_thuthapthongtinthitruong_truyvantt_kiemtra_cau";
                    return RedirectToAction("VanTinKiemTraXacThucCauLD", "TruyVanThongTinCauLaoDong", new { huyen = model.Huyen, xa = model.Xa, TinhTrangXacThuc = model.TinhTrangXacThuc });
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
