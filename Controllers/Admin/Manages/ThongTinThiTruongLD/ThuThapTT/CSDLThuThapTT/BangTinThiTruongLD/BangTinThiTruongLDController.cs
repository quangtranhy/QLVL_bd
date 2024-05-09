using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu;

namespace QLViecLam.Controllers.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.CSDLThuThapTT.BangTinThiTruongLD
{
    public class BangTinThiTruongLDController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BangTinThiTruongLDController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("BangTinThiTruongLD")]
        [HttpGet]
        public IActionResult Index(string khuvuc, string huyen, string xa, string thatnghiep)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    var model = _db.NhanKhau.AsQueryable();
                    //thamgiahdkt
                    ViewData["thamgiahdkt"] = model.Where(x => x.KhongThamGiaHdkt == "0").Count();
                    ViewData["non_thamgiahdkt"] = model.Where(x => x.KhongThamGiaHdkt == "1").Count();

                    //TRINH DO CHUYEN MON KY THUAT
                    //nếu để ChuyenMonKyThuat trong nhankhau là mã thì phải join mà đọc ra tên trình độ
                    var DmTrinhDoKyThuat = model.GroupBy(x => x.ChuyenMonKyThuat)
                        .Select(group => new VM_Count_LucLuongLD
                        {
                            Mota = group.Key,
                        });
                    List<VM_Count_LucLuongLD> dataDmTrinhDoKyThuat = new List<VM_Count_LucLuongLD>();
                    if (DmTrinhDoKyThuat.Any())
                    {
                        foreach (var item in DmTrinhDoKyThuat)
                        {
                            int count = model.Where(t => t.ChuyenMonKyThuat == item.Mota).Count();
                            if (count > 0)
                            {
                                dataDmTrinhDoKyThuat.Add(new VM_Count_LucLuongLD
                                {
                                    Mota = item.Mota,
                                    Count = count
                                });
                            }
                        }
                    }
                    ViewData["number_dmtrinhdokythuat"] = model.Select(x => x.ChuyenMonKyThuat).Distinct().Count();
                    ViewData["DmTrinhDoKyThuat"] = dataDmTrinhDoKyThuat;

                    //chuyen nghanh
                    var ChuyenNganh = model.GroupBy(x => x.ChuyenNganh)
                        .Select(group => new VM_Count_LucLuongLD
                        {
                            Mota = group.Key,
                        });
                    List<VM_Count_LucLuongLD> dataChuyenNganh = new List<VM_Count_LucLuongLD>();
                    if (ChuyenNganh.Any())
                    {
                        foreach (var item in ChuyenNganh)
                        {
                            int count = model.Where(t => t.ChuyenNganh == item.Mota).Count();
                            if (count > 0)
                            {
                                dataChuyenNganh.Add(new VM_Count_LucLuongLD
                                {
                                    Mota = item.Mota,
                                    Count = count
                                });
                            }
                        }
                    }
                    ViewData["number_chuyenganh"] = model.Select(x => x.ChuyenNganh).Distinct().Count();
                    ViewData["ChuyenNganh"] = dataChuyenNganh;

                    //khu vuc
                    ViewData["nongthon"] = model.Where(x => x.KhuVuc == 0).Count();
                    ViewData["thanhthi"] = model.Where(x => x.KhuVuc == 1).Count();

                    //that nghiep
                    ViewData["thatnghiep"] = model.Where(x => x.ThatNghiep == "1").Count();
                    ViewData["non_thatnghiep"] = model.Where(x => x.ThatNghiep == "0").Count();

                    ViewData["Title"] = "Báo cáo";


                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/BangTinThiTruongLD/Index.cshtml");
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
        [Route("BangTinThiTruongLD/Print")]
        [HttpGet]
        public IActionResult Print()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["DmLoaiHinhHdkt"] = _db.DmLoaiHinhHdkt;
                    return View("Views/Admin/Manages/ThongTinThiTruongLD/ThuThapTT/CSDLThuThapTT/BangTinThiTruongLD/BangTinThiTruongLD_Print.cshtml");
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
