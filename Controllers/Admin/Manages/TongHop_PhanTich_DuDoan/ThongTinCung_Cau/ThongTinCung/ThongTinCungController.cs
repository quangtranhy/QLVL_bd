using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.DanhMuc;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using QLViecLam.Models.Admin.Systems;
using System;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.ThongTinCung_Cau.ThongTinCung
{
    public class ThongTinCungController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ThongTinCungController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("ThongTinCung")]
        [HttpGet]
        public IActionResult Index(string huyen, string xa, string kydieutra)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var Madv = "";
                    if (string.IsNullOrEmpty(xa))
                    {
                        Madv = _db.DmDonvi.FirstOrDefault()!.MaDonVi!;
                    }
                    else
                    {
                        Madv = _db.DmDonvi.Where(x => x.MaDiaBan == xa).FirstOrDefault()!.MaDonVi!;
                    }

                    kydieutra = (string.IsNullOrEmpty(kydieutra)) ? "2022" : kydieutra;
                    var model = _db.NhanKhau.Where(x => x.MaDonVi == Madv && x.KyDieuTra == kydieutra).AsQueryable();
                    /*if (loai == null)
                    {
                        model = model.Where(x => x.nguoicovieclam == "1");
                    }*/
                    ViewData["Madv"] = Madv;
                    ViewData["mahuyen"] = huyen;
                    ViewData["maxa"] = xa;
                    ViewData["kydieutra"] = kydieutra;
                    //ViewData["Tinh"] = _db.DmHanhChinh.Where(t => string.IsNullOrEmpty(t.parent) || t.parent == "0");
                    ViewData["Huyen"] = _db.DmHanhChinh.Where(t => t.CapDo == "H");
                    if (string.IsNullOrEmpty(xa))
                    {
                        ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X");
                    }
                    else
                    {
                        ViewData["Xa"] = _db.DmHanhChinh.Where(t => t.CapDo == "X" && t.Parent == huyen);
                    }

                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtincunglaodong";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/ThongTinCung/Index.cshtml", model);
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
        [Route("ThongTinCung/Create")]
        [HttpGet]
        public IActionResult Create(string Madv, string KyDieuTra)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new NhanKhau
                    {
                        MaDonVi = Madv,
                        KyDieuTra = KyDieuTra
                    };

                    ViewData["Madv"] = Madv;
                    ViewData["KyDieuTra"] = KyDieuTra;
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtincunglaodong";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/ThongTinCung/Create.cshtml", model);
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
        [Route("ThongTinCung/Store")]
        [HttpPost]
        public IActionResult Store(NhanKhau request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = new NhanKhau
                    {
                        GioiTinh = request.GioiTinh,
                        HoTen = request.HoTen,
                        NgaySinh = request.NgaySinh,
                        Cccd = request.Cccd,
                        Bhxh = request.Bhxh,
                        ThuongTru = request.ThuongTru,
                        DiaChi = request.DiaChi,
                        UuTien = request.UuTien,
                        DanToc = request.DanToc,
                        TrinhDoGiaoDuc = request.TrinhDoGiaoDuc,
                        ChuyenMonKyThuat = request.ChuyenMonKyThuat,
                        ChuyenNganh = request.ChuyenNganh,
                        TinhTrangHdkt = request.TinhTrangHdkt,
                        NguoiCoVieclam = request.NguoiCoVieclam,
                        CongViecCuThe = request.CongViecCuThe,
                        ThamGiaBhxh = request.ThamGiaBhxh,
                        Hdld = request.Hdld,
                        NoiLamViec = request.NoiLamViec,
                        LoaiHinhNoiLamViec = request.LoaiHinhNoiLamViec,
                        DiaChiNoiLamViec = request.DiaChiNoiLamViec,
                        ThatNghiep = request.ThatNghiep,
                        ThoiGianThatNghiep = request.ThoiGianThatNghiep,
                        KhongThamGiaHdkt = request.KhongThamGiaHdkt,
                        Ho = request.Ho,
                        Mqh = request.Mqh,
                        MaLoi = request.MaLoi,
                        MaLoaiLoi = request.MaLoaiLoi,
                        MaDonVi = request.MaDonVi,
                        KyDieuTra = request.KyDieuTra,
                        SoLuongTrung = request.SoLuongTrung,
                        LoaiBienDong = request.LoaiBienDong,
                        RuongBienDong = request.RuongBienDong,
                        DoiTuongTimViecLam = request.DoiTuongTimViecLam,
                        ViecLamMongMuon = request.ViecLamMongMuon,
                        NganhNgheMongMuon = request.NganhNgheMongMuon,
                        NganhNgheMuonHoc = request.NganhNgheMuonHoc,
                        TrinhDoChuyenMonMuonHoc = request.TrinhDoChuyenMonMuonHoc,
                        Sdt = request.Sdt,
                        KhuVuc = request.KhuVuc,
                        ThiTruongLamViec = request.ThiTruongLamViec,
                        LyDo = request.LyDo,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now,
                    };
                    _db.NhanKhau.Add(model);
                    _db.SaveChanges();
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtincunglaodong";
                    return RedirectToAction("Index", "ThongTinCung");
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
        [Route("ThongTinCung/Edit")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.FirstOrDefault(t => t.Id == Id);
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtincunglaodong";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/ThongTinCung_Cau/ThongTinCung/Edit.cshtml", model);
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
        [Route("ThongTinCung/Update")]
        [HttpPost]
        public IActionResult Update(NhanKhau request)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.FirstOrDefault(t => t.Id == request.Id);
                    model.GioiTinh = request.GioiTinh;
                    model.HoTen = request.HoTen;
                    model.NgaySinh = request.NgaySinh;
                    model.Cccd = request.Cccd;
                    model.Bhxh = request.Bhxh;
                    model.ThuongTru = request.ThuongTru;
                    model.DiaChi = request.DiaChi;
                    model.UuTien = request.UuTien;
                    model.DanToc = request.DanToc;
                    model.TrinhDoGiaoDuc = request.TrinhDoGiaoDuc;
                    model.ChuyenMonKyThuat = request.ChuyenMonKyThuat;
                    model.ChuyenNganh = request.ChuyenNganh;
                    model.TinhTrangHdkt = request.TinhTrangHdkt;
                    model.NguoiCoVieclam = request.NguoiCoVieclam;
                    model.CongViecCuThe = request.CongViecCuThe;
                    model.ThamGiaBhxh = request.ThamGiaBhxh;
                    model.Hdld = request.Hdld;
                    model.NoiLamViec = request.NoiLamViec;
                    model.LoaiHinhNoiLamViec = request.LoaiHinhNoiLamViec;
                    model.DiaChiNoiLamViec = request.DiaChiNoiLamViec;
                    model.ThatNghiep = request.ThatNghiep;
                    model.ThoiGianThatNghiep = request.ThoiGianThatNghiep;
                    model.KhongThamGiaHdkt = request.KhongThamGiaHdkt;
                    model.Ho = request.Ho;
                    model.Mqh = request.Mqh;
                    model.MaLoi = request.MaLoi;
                    model.MaLoaiLoi = request.MaLoaiLoi;
                    model.MaDonVi = request.MaDonVi;
                    model.KyDieuTra = request.KyDieuTra;
                    model.SoLuongTrung = request.SoLuongTrung;
                    model.LoaiBienDong = request.LoaiBienDong;
                    model.RuongBienDong = request.RuongBienDong;
                    model.DoiTuongTimViecLam = request.DoiTuongTimViecLam;
                    model.ViecLamMongMuon = request.ViecLamMongMuon;
                    model.NganhNgheMongMuon = request.NganhNgheMongMuon;
                    model.NganhNgheMuonHoc = request.NganhNgheMuonHoc;
                    model.TrinhDoChuyenMonMuonHoc = request.TrinhDoChuyenMonMuonHoc;
                    model.Sdt = request.Sdt;
                    model.KhuVuc = request.KhuVuc;
                    model.ThiTruongLamViec = request.ThiTruongLamViec;
                    model.LyDo = request.LyDo;
                    model.Created_at = DateTime.Now;
                    model.Updated_at = DateTime.Now;

                    _db.NhanKhau.Update(model);
                    _db.SaveChanges();
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtincunglaodong";
                    return RedirectToAction("Index", "ThongTinCung");
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
        [Route("ThongTinCung/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.FirstOrDefault(t => t.Id == id_delete);
                    _db.NhanKhau.Remove(model);
                    _db.SaveChanges();
                    ViewData["MenuLv1"] = "menu_capnhatcungcau";
                    ViewData["MenuLv2"] = "menu_capnhatcungcau_thongtincunglaodong";
                    return RedirectToAction("Index", "ThongTinCung");
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
