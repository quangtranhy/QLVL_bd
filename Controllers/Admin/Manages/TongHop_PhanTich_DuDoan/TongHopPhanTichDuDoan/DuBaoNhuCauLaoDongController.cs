using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Models.Admin.Manages.ThongTinThiTruongLD;
using QLViecLam.ViewModels.Admin.Manages.ThongTinThiTruongLD.ThuThapTT.HeThongTruyVanTT;
using QLViecLam.ViewModels.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan;

namespace QLViecLam.Controllers.Admin.Manages.TongHop_PhanTich_DuDoan.TongHopPhanTichDuDoan
{
    public class DuBaoNhuCauLaoDongController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DuBaoNhuCauLaoDongController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Route("DuBaoNhuCauLaoDong")]
        [HttpGet]
        public IActionResult Index()
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


                    return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/DuBaoThiTruongLaoDong.cshtml",model);
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
