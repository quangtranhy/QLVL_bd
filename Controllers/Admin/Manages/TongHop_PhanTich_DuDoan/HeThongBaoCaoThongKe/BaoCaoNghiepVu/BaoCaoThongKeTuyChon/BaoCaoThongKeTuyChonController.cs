using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.DanhMuc;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.HeThongBaoCaoThongKe.BaoCaoNghiepVu.BaoCaoThongKeTuyChon
{
    public class BaoCaoThongKeTuyChonController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BaoCaoThongKeTuyChonController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("BaoCaoThongKeTuyChon")]
        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoThongKeTuyChon";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoThongKeTuyChon/Index.cshtml");
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
        [Route("BaoCaoThongKeTuyChon/Print")]
        [HttpGet]
        public IActionResult Print(string type)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                bool check_per = true;
                if (check_per)
                {
                    ViewData["type"] = type;

                    var model = _db.NhanKhau.AsQueryable();

                    if (type == "nganhnghe")
                    {
                        var nganhnghe = model.GroupBy(x => x.CongViecCuThe)
                            .Select(group => new VM_Count_LucLuongLD
                            {
                                Mota = group.Key,
                                Count = group.Count(),
                            });
                        ViewData["nganhnghe"] = nganhnghe;
                        ViewData["nameReport"] = "ngành nghề";
                    }

                    if (type == "gioitinh")
                    {
                        var gioitinh = model.GroupBy(x => x.GioiTinh)
                            .Select(group => new VM_Count_LucLuongLD
                            {
                                Mota = group.Key,
                                Count = group.Count(),
                            });
                        ViewData["gioitinh"] = gioitinh;
                        ViewData["nameReport"] = "giới tính";
                    }

                    if (type == "dantoc")
                    {
                        var dantoc = model.GroupBy(x => x.DanToc)
                            .Select(group => new VM_Count_LucLuongLD
                            {
                                Mota = group.Key,
                                Count = group.Count(),
                            });
                        ViewData["dantoc"] = dantoc;
                        ViewData["nameReport"] = "dân tộc";
                    }
                    ViewData["MenuLv1"] = "menu_hethongbaocaothongke";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu";
                    ViewData["MenuLv2"] = "menu_hethongbaocaothongke_nghiepvu_BaoCaoThongKeTuyChon";

                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/HeThongBaoCaoThongKe/BaoCaoNghiepVu/BaoCaoThongKeTuyChon/Print.cshtml");
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
