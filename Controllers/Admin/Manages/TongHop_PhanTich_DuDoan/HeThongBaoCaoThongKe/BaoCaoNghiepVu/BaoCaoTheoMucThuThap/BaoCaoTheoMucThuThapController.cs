using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.HeThongTruyVanTT;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.BaoCaoTheoMucThuThap
{
    public class BaoCaoTheoMucThuThapController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BaoCaoTheoMucThuThapController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("BaoCaoTheoMucThuThap")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "";
                    ViewData["MenuLv2"] = "";
                    ViewData["MenuLv2"] = "";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoTheoMucThuThap/Index.cshtml");
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
        [Route("BaoCaoTheoMucThuThap/BaoHiemXaHoi")]
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
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoTheoMucThuThap/BaoHiemXaHoi.cshtml", dataCheDoChinhSach);
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

        [Route("BaoCaoTheoMucThuThap/BaoHiemYTe")]
        [HttpGet]
        public IActionResult BaoHiemYTe()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    //co bao hiem tn
                    var result = (from nguoi in _db.NguoiLaoDong
                                  join chinhSach in _db.CheDoChinhSach.Where(x => x.Bhyt > 0)
                                  on nguoi.SoBaoHiem equals chinhSach.MaBhxh
                                  select new VM_BaoHiemXaHoi
                                  {
                                      MaBhxh = nguoi.SoBaoHiem,
                                  }).Count();

                    ViewData["CoBhtn"] = result;
                    ViewData["KoCoBhtn"] = _db.NguoiLaoDong.Count() - result;
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoTheoMucThuThap/BaoHiemYTe.cshtml");
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

        [Route("BaoCaoTheoMucThuThap/MucThuNhap")]
        [HttpGet]
        public IActionResult MucThuNhap()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    //co bao hiem tn
                    var count= _db.NguoiLaoDong.AsEnumerable().Where(nld => long.Parse(nld.Luong!) < 9990000).Count();
                    ViewData["MucLuong1"] = count;
                    ViewData["MucLuong2"] = _db.NguoiLaoDong.Count() - count;
                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoTheoMucThuThap/MucThuNhap.cshtml");
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

        [Route("BaoCaoTheoMucThuThap/DonViSuDungLaoDong")]
        [HttpGet]
        public IActionResult DonViSuDungLaoDong()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var NguoiLaoDong = _db.NguoiLaoDong.GroupBy(nld=>nld.Company)
                        .Select(group => new VM_Count_Chucnang
                        {
                            Mota = group.Key.ToString(),
                        });
                    List<VM_Count_Chucnang> dataNguoiLaoDong = new List<VM_Count_Chucnang>();
                    if (NguoiLaoDong.Any())
                    {
                        foreach (var item in NguoiLaoDong)
                        {
                            int count = _db.NguoiLaoDong.Where(t => t.Company == int.Parse(item.Mota!)).Count();
                            if (count > 0)
                            {
                                dataNguoiLaoDong.Add(new VM_Count_Chucnang
                                {
                                    Mota = item.Mota,
                                    Count = count
                                });
                            }
                        }
                    }

                    var result = (from nld in dataNguoiLaoDong
                                  join dn in _db.Company
                                  on nld.Mota equals dn.Id.ToString()
                                  select new VM_Count_Chucnang
                                  {
                                      Mota = dn.Name,
                                      Count = nld.Count
                                  });

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoTheoMucThuThap/DonViSuDungLaoDong.cshtml", result);
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
