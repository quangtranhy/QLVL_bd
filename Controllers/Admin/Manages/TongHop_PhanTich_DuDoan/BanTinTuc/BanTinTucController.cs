using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;

namespace QLViecLam.Controllers.Admin.Manages.BanTinTuc
{
    public class BanTinTucController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BanTinTucController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Route("BanTin")]
        [HttpGet]
        public IActionResult Index()
        {

            var model = _db.BanTin;

            return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/BanTinTuc/Index.cshtml", model);
        }

        [Route("BanTin/Create")]
        [HttpGet]
        public IActionResult Create()
        {

            return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/BanTinTuc/Create.cshtml");
        }

        [Route("BanTin/Store")]
        [HttpPost]
        public IActionResult Store(string TieuDe, string TrangThai, string MoTa, DateTime ThoiDiem, string NoiDung)
        {
            var model = new QLViecLam.Models.Admin.Manages.TongHop_PhanTich_DuDoan.BanTin
            {
                TieuDe = TieuDe,
                TrangThai = TrangThai,
                MoTa = MoTa,
                ThoiDiem = ThoiDiem,
                NoiDung = NoiDung,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now,
            };
            _db.BanTin.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index", "BanTin");
        }

        [Route("BanTin/Edit")]
        [HttpGet]
        public IActionResult Edit(int id_edit)
        {
            var model = _db.BanTin.FirstOrDefault(p => p.Id == id_edit);

            return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/BanTinTuc/Edit.cshtml", model);
        }

        [Route("BanTin/Update")]
        [HttpPost]
        public IActionResult Update(int id_edit, string TieuDe, string TrangThai, string MoTa, DateTime ThoiDiem, string NoiDung)
        {

            var model = _db.BanTin.FirstOrDefault(t => t.Id == id_edit);

            if (model != null)
            {
                model.TieuDe = TieuDe;
                model.TrangThai = TrangThai;
                model.MoTa = MoTa;
                model.ThoiDiem = ThoiDiem;
                model.NoiDung = NoiDung;
                model.Updated_at = DateTime.Now;
                _db.BanTin.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "BanTin");
        }

        [Route("BanTin/Show")]
        [HttpGet]
        public IActionResult Show(int id_show)
        {

            var model = _db.BanTin.FirstOrDefault(p => p.Id == id_show);

            return View("Views/Admin/Manages/TongHop_PhanTich_DuDoan/BanTinTuc/Show.cshtml", model);
        }

        [Route("BanTin/Delete")]
        [HttpPost]
        public IActionResult Delete(int id_delete)
        {
            var model = _db.BanTin.FirstOrDefault(t => t.Id == id_delete);
            if (model != null)
            {
                _db.BanTin.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "BanTin");
        }
    }
}
