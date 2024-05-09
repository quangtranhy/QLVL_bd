using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.DanhMuc;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;
using QLViecLam.Models.Admin.Systems;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.HeThongTruyVanTT;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan;
using System.Diagnostics.Metrics;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan
{
    public class TongHopPhanTichDuDoanController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TongHopPhanTichDuDoanController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("TongHopPhanTichDuDoan")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["dmdoituonguutiens"] = _db.DmDoiTuongUuTien;
                    ViewData["dmtrinhdogdpt"] = _db.DmTrinhDoGdpt;
                    ViewData["dmtrinhdokythuat"] = _db.DmTrinhDoKyThuat;
                    ViewData["dmtinhtrangthamgiahdkt"] = _db.DmLoaiHinhHdkt;

                    ViewData["MenuLv1"] = "menu_tonghopphantichdubaoTT";
                    ViewData["MenuLv2"] = "menu_tonghopphantichdubao";
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/Index.cshtml");
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

        [Route("TongHopPhanTichDuDoan/LucLuongLaoDong")]
        [HttpGet]
        public IActionResult LucLuongLaoDong(string kydieutra, string gender, string tthdkt, string dtut, string trinhdogdpt, string trinhdocmkt,
            string gioitinh, string tinhtranghdkt, string uutien, string trinhdogiaoduc, string chuyenmonkythuat)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var danhmuchanhchinh = _db.DmHanhChinh;

                    var dmdonvi = _db.DmDonvi;
                    var nhankhau = _db.NhanKhau.Where(x => x.KyDieuTra == kydieutra);
                    ViewData["titleSL"] = "Danh sách Tổng hợp, phân tích, thống kê số liệu Lực lượng lao động";
                    if (gender == "gender")
                    {
                        nhankhau = nhankhau.Where(x => x.GioiTinh == gioitinh);
                        ViewData["titleSL"] += " giới tính " + gioitinh;
                    }
                    if (dtut == "dtut")
                    {
                        nhankhau = nhankhau.Where(x => x.UuTien == uutien);
                        ViewData["titleSL"] += " ưu tiên " + uutien;
                    }
                    if (trinhdogdpt == "trinhdogdpt")
                    {
                        ViewData["titleSL"] += " trình độ giáo dục  " + trinhdogiaoduc;
                        nhankhau = nhankhau.Where(x => x.TrinhDoGiaoDuc == trinhdogiaoduc);
                    }
                    if (trinhdocmkt == "trinhdocmkt")
                    {
                        ViewData["titleSL"] += " trình độ chuyên môn kĩ thuật " + chuyenmonkythuat;
                        nhankhau = nhankhau.Where(x => x.ChuyenMonKyThuat == chuyenmonkythuat);
                    }
                    var hanhchinh = (from hc in danhmuchanhchinh
                                     join dv in dmdonvi
                                     on hc.Id equals Convert.ToInt16(dv.MaDiaBan)
                                     //join nk in nhankhau
                                     //on dv.MaDonVi equals nk.MaDonVi
                                     select new DmHanhChinh
                                     {
                                         Parent = hc.Parent,
                                         Name = hc.Name,
                                         MaDvql = dv.MaDonVi,
                                         CapDo = hc.CapDo,
                                         MaDb = dv.MaDiaBan,
                                         MaQuocGia = hc.MaQuocGia,
                                     });
                    var hanhchinh_tinh = hanhchinh.Where(x => x.CapDo == "T");
                    var hanhchinh_huyen = hanhchinh.Where(x => x.CapDo == "H");
                    var hanhchinh_xa = hanhchinh.Where(x => x.CapDo == "X");

                    var newhanhchinh_x = new List<DmHanhChinh>();
                    var newhanhchinh_h = new List<DmHanhChinh>();
                    var newhanhchinh_t = new List<DmHanhChinh>();
                    foreach (var hc in hanhchinh_xa)
                    {
                        var mdb = (hc.Id).ToString();

                        newhanhchinh_x.Add(new DmHanhChinh
                        {
                            Parent = hc.Parent,
                            Name = hc.Name,
                            Count = nhankhau.Where(x => x.MaDonVi == hc.MaDvql).Count(),
                        });
                    }

                    foreach (var hc_h in hanhchinh_huyen)
                    {
                        int count = 0;
                        foreach (var hc_x in newhanhchinh_x)
                        {
                            if (hc_x.Parent == hc_h.MaQuocGia)
                            {
                                count = count + (int)(hc_x.Count);
                            }
                        }
                        newhanhchinh_h.Add(new DmHanhChinh
                        {
                            Name = hc_h.Name,
                            Count = count,
                        });

                    }

                    foreach (var hc_t in hanhchinh_tinh)
                    {
                        newhanhchinh_t.Add(new DmHanhChinh
                        {
                            Name = hc_t.Name,
                            Count = nhankhau.Count(),
                        });
                    }

                    foreach (var item in newhanhchinh_h)
                    {
                        newhanhchinh_t.Add(item);
                    }
                    foreach (var item in newhanhchinh_x)
                    {
                        newhanhchinh_t.Add(item);
                    }


                    ViewData["hanhchinh_h"] = newhanhchinh_t;


                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/LucLuongLaoDong.cshtml", newhanhchinh_t);
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

        [Route("TongHopPhanTichDuDoan/ThatNghiep")]
        [HttpGet]
        public IActionResult ThatNghiep(string tthdkt, string kydieutra, string gender, string dtut, string trinhdogdpt, string trinhdocmkt,
            string gioitinh, string tinhtranghdkt, string uutien, string trinhdogiaoduc, string chuyenmonkythuat)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var danhmuchanhchinh = _db.DmHanhChinh;
                    var dmdonvi = _db.DmDonvi;
                    var nhankhau = _db.NhanKhau.Where(x => x.KyDieuTra == kydieutra);
                    if (tthdkt == "thatnghiep")
                    {
                        nhankhau = nhankhau.Where(x => x.TinhTrangHdkt == "2");
                    }
                    if (gender == "gender")
                    {
                        nhankhau = nhankhau.Where(x => x.GioiTinh == gioitinh);
                    }
                    if (dtut == "dtut")
                    {
                        nhankhau = nhankhau.Where(x => x.UuTien == uutien);
                    }
                    if (trinhdogdpt == "trinhdogdpt")
                    {
                        nhankhau = nhankhau.Where(x => x.TrinhDoGiaoDuc == trinhdogiaoduc);
                    }
                    if (trinhdocmkt == "trinhdocmkt")
                    {
                        nhankhau = nhankhau.Where(x => x.ChuyenMonKyThuat == chuyenmonkythuat);
                    }

                    var hanhchinh = (from hc in danhmuchanhchinh
                                     join dv in dmdonvi
                                     on hc.Id equals Convert.ToInt16(dv.MaDiaBan)
                                     //join nk in nhankhau
                                     //on dv.MaDonVi equals nk.MaDonVi
                                     select new DmHanhChinh
                                     {
                                         Parent = hc.Parent,
                                         Name = hc.Name,
                                         MaDvql = dv.MaDonVi,
                                         CapDo = hc.CapDo,
                                         MaDb = dv.MaDiaBan,
                                         MaQuocGia = hc.MaQuocGia,
                                     });
                    var hanhchinh_tinh = hanhchinh.Where(x => x.CapDo == "T");
                    var hanhchinh_huyen = hanhchinh.Where(x => x.CapDo == "H");
                    var hanhchinh_xa = hanhchinh.Where(x => x.CapDo == "X");

                    var newhanhchinh_x = new List<DmHanhChinh>();
                    var newhanhchinh_h = new List<DmHanhChinh>();
                    var newhanhchinh_t = new List<DmHanhChinh>();
                    foreach (var hc in hanhchinh_xa)
                    {
                        var mdb = (hc.Id).ToString();

                        newhanhchinh_x.Add(new DmHanhChinh
                        {
                            Parent = hc.Parent,
                            Name = hc.Name,
                            Count = nhankhau.Where(x => x.MaDonVi == hc.MaDvql).Count(),
                        });
                    }

                    foreach (var hc_h in hanhchinh_huyen)
                    {
                        int count = 0;
                        foreach (var hc_x in newhanhchinh_x)
                        {
                            if (hc_x.Parent == hc_h.MaQuocGia)
                            {
                                count = count + (int)(hc_x.Count);
                            }
                        }
                        newhanhchinh_h.Add(new DmHanhChinh
                        {
                            Name = hc_h.Name,
                            Count = count,
                        });

                    }

                    foreach (var hc_t in hanhchinh_tinh)
                    {
                        newhanhchinh_t.Add(new DmHanhChinh
                        {
                            Name = hc_t.Name,
                            Count = nhankhau.Count(),
                        });
                    }

                    foreach (var item in newhanhchinh_h)
                    {
                        newhanhchinh_t.Add(item);
                    }
                    foreach (var item in newhanhchinh_x)
                    {
                        newhanhchinh_t.Add(item);
                    }

                    ViewData["hanhchinh_h"] = newhanhchinh_t;
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/ThatNghiep.cshtml", newhanhchinh_t);
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

        [Route("TongHopPhanTich/SoLieuNganhNghe")]
        [HttpGet]
        public IActionResult SoLieuNganhNghe()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var NguoiLaoDong = _db.NguoiLaoDong.Where(x=>x.NgheNghiep != null);


                    var model = NguoiLaoDong.GroupBy(x => x.NgheNghiep)
                        .Select(group => new VM_Count_Chucnang
                        {
                            Mota = group.Key,
                            Count = group.Count(),
                        });
          

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/SoLieuNganhNghe.cshtml", model);
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

        [Route("TongHopPhanTich/SoLieuViecLam")]
        [HttpGet]
        public IActionResult SoLieuViecLam(DateTime tungay, DateTime denngay)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = (from dn in _db.Company
                                 join td in _db.TuyenDung
                                 on dn.User equals td.User
                                 join vt in _db.ViTriTuyenDung
                                on td.Id equals vt.IdTuyenDung
                                 select new VM_SoLieuViecLam
                                 {
                                     Xa = dn.Xa!,
                                     Huyen = dn.Huyen!,
                                     Soluong = vt.Soluong!,
                                 });
                    //count theo Huyen
                    var countH = model.GroupBy(x => x.Huyen)
                        .Select(group => new VM_Count_Chucnang
                        {
                            Mota = group.Key,
                            Count = group.Sum(x => x.Soluong!),
                        });
                    //count theo Xa
                    var countX = model.GroupBy(x => x.Xa)
                        .Select(group => new VM_Count_Chucnang
                        {
                            Mota = group.Key,
                            Count = group.Sum(x => x.Soluong!),
                        });
                    //count ca Tinh
                    int countT = (int)model.Sum(x => x.Soluong)!;

                    var danhmuchanhchinh = _db.DmHanhChinh;
                    int stt = 1;
                    int stt_h = 1;
                    int stt_x = 1;
                    var newList = new List<DmHanhChinh>();

                    foreach (var item in danhmuchanhchinh.Where(t => string.IsNullOrEmpty(t.Parent) || t.Parent == "0"))
                    {
                        var dmhanhchinhhuyen = danhmuchanhchinh.Where(h => h.Parent == item.MaQuocGia);
                        newList.Add(new DmHanhChinh
                        {
                            Stt = stt++,
                            Name = item.Name,
                            CapDo = item.CapDo,
                            Parent = item.Parent,
                            MaQuocGia = item.MaQuocGia,
                            Count = countT,
                        });
                        foreach (var dbhuyen in dmhanhchinhhuyen)
                        {
                            var dmhanhchinhxa = danhmuchanhchinh.Where(x => x.Parent == dbhuyen.MaQuocGia);

                            if (countH != null)
                            {
                                if (countH.Where(x => x.Mota == dbhuyen.Name).Any())
                                {
                                    newList.Add(new DmHanhChinh
                                    {
                                        Stt = stt_x++,
                                        Name = dbhuyen.Name,
                                        CapDo = dbhuyen.CapDo,
                                        Parent = dbhuyen.Parent,
                                        MaQuocGia = dbhuyen.MaQuocGia,
                                        Count = (int)countH.FirstOrDefault(x => x.Mota == dbhuyen.Name)!.Count!,
                                    });
                                }
                                //neu ko co thi count 0
                                else
                                {
                                    newList.Add(new DmHanhChinh
                                    {
                                        Stt = stt_h++,
                                        Name = dbhuyen.Name,
                                        CapDo = dbhuyen.CapDo,
                                        Parent = dbhuyen.Parent,
                                        MaQuocGia = dbhuyen.MaQuocGia,
                                        Count = 0,
                                    });
                                }
                            }


                            foreach (var dbxa in dmhanhchinhxa)
                            {
                                if (countX != null)
                                {
                                    if (countX.Where(x => x.Mota == dbxa.Name).Any())
                                    {
                                        newList.Add(new DmHanhChinh
                                        {
                                            Stt = stt_x++,
                                            Name = dbxa.Name,
                                            CapDo = dbxa.CapDo,
                                            Parent = dbxa.Parent,
                                            MaQuocGia = dbxa.MaQuocGia,
                                            Count = (int)countX.FirstOrDefault(x => x.Mota == dbxa.Name)!.Count!,
                                        });
                                    }
                                    //neu ko co thi count 0
                                    else
                                    {
                                        newList.Add(new DmHanhChinh
                                        {
                                            Stt = stt_x++,
                                            Name = dbxa.Name,
                                            CapDo = dbxa.CapDo,
                                            Parent = dbxa.Parent,
                                            MaQuocGia = dbxa.MaQuocGia,
                                            Count = 0,
                                        });
                                    }
                                }


                            }
                            stt_x = 1;
                        }
                    }

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/SoLieuViecLam.cshtml", newList);
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



        [Route("TongHopPhanTich/BaoHiemXaHoi")]
        [HttpGet]
        public IActionResult BaoHiemXaHoi()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {

                    var result = from nguoi in _db.NguoiLaoDong
                                 join chinhSach in _db.CheDoChinhSach
                                 on nguoi.SoBaoHiem equals chinhSach.MaBhxh
                                 into left
                                 from subChinhSach in left.DefaultIfEmpty()
                                 select new VM_BaoHiemXaHoi
                                 {
                                     MaBhxh = nguoi.SoBaoHiem,
                                     ThamGiaBaoHiem = subChinhSach != null ? subChinhSach.GhiChu : "3"
                                 };

                    var CheDoChinhSach = result.GroupBy(x => x.ThamGiaBaoHiem)
                        .Select(group => new VM_Count_Chucnang
                        {
                            Mota = group.Key,
                        });
                    List<VM_Count_Chucnang> dataCheDoChinhSach = new List<VM_Count_Chucnang>();
                    if (CheDoChinhSach.Any())
                    {
                        foreach (var item in CheDoChinhSach)
                        {
                            int count = result.Where(t => t.ThamGiaBaoHiem == item.Mota).Count();
                            if (count > 0)
                            {
                                dataCheDoChinhSach.Add(new VM_Count_Chucnang
                                {
                                    Mota = item.Mota,
                                    Count = count
                                });
                            }
                        }
                    }
                    //return Ok(dataCheDoChinhSach);
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/BaoHiemXaHoi.cshtml", dataCheDoChinhSach);
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

        [Route("TongHopPhanTich/BaoHiemThatNghiep")]
        [HttpGet]
        public IActionResult BaoHiemThatNghiep()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    //co bao hiem tn
                    var result = (from nguoi in _db.NguoiLaoDong
                                  join chinhSach in _db.CheDoChinhSach.Where(x => x.Bhtn > 0)
                                  on nguoi.SoBaoHiem equals chinhSach.MaBhxh
                                  select new VM_BaoHiemXaHoi
                                  {
                                      MaBhxh = nguoi.SoBaoHiem,
                                  }).Count();

                    ViewData["CoBhtn"] = result;
                    ViewData["KoCoBhtn"] = _db.NguoiLaoDong.Count() - result;
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/BaoHiemThatNghiep.cshtml");
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


        [Route("TongHopPhanTich/MucThuNhap")]
        [HttpGet]
        public IActionResult MucThuNhap()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var nguoilaodong = _db.NguoiLaoDong;
                    var model = new List<VM_Count_Chucnang>();
                    model.Add(new VM_Count_Chucnang
                    {
                        Mota = "Lương dưới 5 triệu",
                        Count = nguoilaodong.Where(x => Convert.ToInt64(x.Luong) < 5000000).Count(),
                    });
                    model.Add(new VM_Count_Chucnang
                    {
                        Mota = "Lương từ 5 đến 10 triệu",
                        Count = nguoilaodong.Where(x => Convert.ToInt64(x.Luong) >= 5000000 && Convert.ToInt64(x.Luong) < 10000000).Count(),
                    });
                    model.Add(new VM_Count_Chucnang
                    {
                        Mota = "Lương từ 10 đến 20 triệu",
                        Count = nguoilaodong.Where(x => Convert.ToInt64(x.Luong) >= 10000000 && Convert.ToInt64(x.Luong) < 20000000).Count(),
                    });
                    model.Add(new VM_Count_Chucnang
                    {
                        Mota = "Lương từ 20 đến 50 triệu",
                        Count = nguoilaodong.Where(x => Convert.ToInt64(x.Luong) >= 20000000 && Convert.ToInt64(x.Luong) < 50000000).Count(),
                    });
                    model.Add(new VM_Count_Chucnang
                    {
                        Mota = "Lương trên 50 triệu",
                        Count = nguoilaodong.Where(x => Convert.ToInt64(x.Luong) > 50000000).Count(),
                    });

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/MucThuNhap.cshtml", model);
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


        [Route("TongHopPhanTich/XuHuongTuyenDung")]
        [HttpGet]
        public IActionResult XuHuongTuyenDung(DateTime tungay, DateTime denngay)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {

                    var TuyenDung = _db.TuyenDung.AsQueryable();

                    if (tungay != null)
                    {
                        TuyenDung = TuyenDung.Where(x => x.ThoiHan >= tungay);
                    }
                    if (denngay != null)
                    {
                        TuyenDung = TuyenDung.Where(x => x.ThoiHan <= denngay);
                    }

                    var ViTriTuyenDung = _db.ViTriTuyenDung.Where(x => x.State == "XD");

                    var model = (from dn in _db.Company
                                 join td in TuyenDung
                                 on dn.User equals td.User
                                 join vt in ViTriTuyenDung
                                on td.Id equals vt.IdTuyenDung
                                 select new VM_XuHuongTuyenDung
                                 {
                                     Nganhnghe = dn.NganhNghe!,
                                     SoLuong = vt.Soluong!,
                                 });

                    //count theo ma nganh nghe
                    var countNganhNghe = model.GroupBy(x => x.Nganhnghe)
                        .Select(group => new VM_Count_Chucnang
                        {
                            Mota = group.Key,
                            Count = group.Sum(x => x.SoLuong!),
                        });
                    int stt = 1;
                    var newList = new List<DmNganhNghe>();
                    var dmnganhnghe = _db.DmNganhNghe;
                    foreach (var nganhnghe in dmnganhnghe)
                    {
                        if (countNganhNghe.Where(x => x.Mota == nganhnghe.MaDm).Any())
                        {
                            newList.Add(new DmNganhNghe
                            {
                                Stt = stt++,
                                TenDm = nganhnghe.TenDm,
                                Count = countNganhNghe.FirstOrDefault(x => x.Mota == nganhnghe.TenDm)!.Count!,
                            });
                        }

                        // khong ton tai count = 0
                        else
                        {
                            newList.Add(new DmNganhNghe
                            {
                                Stt = stt++,
                                TenDm = nganhnghe.TenDm,
                                Count = 0,
                            });
                        }
                    }

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/XuHuongTuyenDung.cshtml", newList);
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

        [Route("TongHopPhanTich/SoLieuThiTruongLaoDong")]
        [HttpGet]
        public IActionResult SoLieuThiTruongLaoDong(string kydieutra)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var tungay = new DateTime(int.Parse(kydieutra), 1, 1);
                    var denngay = new DateTime(int.Parse(kydieutra), 12, 31);

                    var TuyenDung = _db.TuyenDung.Where(x => x.ThoiHan > tungay && x.ThoiHan < denngay);
                    var ViTriTuyenDung = _db.ViTriTuyenDung.Where(x => x.State == "XD");

                    var tuyendung = (from td in TuyenDung
                                     join vt in ViTriTuyenDung
                                    on td.Id equals vt.IdTuyenDung
                                     select new ViTriTuyenDung
                                     {
                                         Tdcmkt = vt.Tdcmkt,
                                         Soluong = vt.Soluong,
                                     });


                    var nhankhau = _db.NhanKhau.Where(x => x.KyDieuTra == kydieutra);

                    var DmTrinhDoKyThuat = _db.DmTrinhDoKyThuat;
                    var model = new List<VM_ThiTruongLaoDong>();
                    foreach (var item in DmTrinhDoKyThuat)
                    {
                        var cau = tuyendung.Where(x => x.Tdcmkt == item.Tentdkt).Sum(x => x.Soluong);
                        var cung = nhankhau.Where(x => x.ChuyenMonKyThuat == item.Tentdkt).Count();
                        model.Add(new VM_ThiTruongLaoDong
                        {
                            Name = item.Tentdkt,
                            Cung = cung,
                            Cau = cau,
                        });

                    }
                    model.Add(new VM_ThiTruongLaoDong
                    {
                        Name = "Tổng",
                        Cung = nhankhau.Count(),
                        Cau = tuyendung.Sum(x => x.Soluong),
                    });

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/ThiTruongLaoDong.cshtml", model);
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

        [Route("TongHopPhanTich/DuBaoNhuCauLaoDong")]
        [HttpGet]
        public IActionResult DuBaoNhuCauLaoDong()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var nhankhau = _db.NhanKhau;
                    var DmNghanhHoc = _db.DmNghanhHoc;
                    var model = new List<VM_Count_Chucnang>();

                    foreach (var item in DmNghanhHoc)
                    {
                        var count = nhankhau.Where(X => X.ViecLamMongMuon == int.Parse(item.MaNghanhHoc!)).Count();
                        if (count > 0)
                        {
                           
                            model.Add(new VM_Count_Chucnang
                            {
                                Mota = item.TenNghanhHoc,
                                Count = count,
                            });
                        }

                    }

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/DuBaoNhuCauLaoDong.cshtml", model);
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

        [Route("TongHopPhanTich/TrienVongThiTruongLaoDong")]
        [HttpGet]
        public IActionResult TrienVongThiTruongLaoDong(DateTime tungay, DateTime denngay)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var dmnganhnghe = _db.DmNganhNghe;

                    var vitrituyendung = _db.ViTriTuyenDung.AsQueryable();


                    var DmNganhNghe = dmnganhnghe.GroupBy(x => x.MaDm)
                        .Select(group => new VM_Count_Chucnang
                        {
                            Mota = group.Key,
                        });
                    List<VM_Count_Chucnang> dataDmNganhNghe = new List<VM_Count_Chucnang>();
                    if (DmNganhNghe.Any())
                    {
                        foreach (var item in DmNganhNghe)
                        {
                            int count = vitrituyendung.Where(t => t.MaNghe == item.Mota).Count();
                            if (count > 0)
                            {
                                dataDmNganhNghe.Add(new VM_Count_Chucnang
                                {
                                    Mota = item.Mota,
                                    Count = count
                                });
                            }
                        }
                    }

                    //ViewData["dataDmNganhNghe"] = dataDmNganhNghe;
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/TongHopPhanTichDuDoan/TrienVongThiTruongLaoDong.cshtml", dataDmNganhNghe);
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
