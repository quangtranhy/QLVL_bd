using Microsoft.AspNetCore.Mvc;
using QLViecLam.Data;
using QLViecLam.Helper;
using QLViecLam.Models;
using QLViecLam.Models.Admin.Systems;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace QLViecLam.Controllers.Admin
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                ViewData["Title"] = "Trang chủ";
                ViewData["MenuLv1"] = "menu_home";
                return View("Views/Admin/Home/Dashboard.cshtml");
            }
        }
        [Route("ChangePassword")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                ViewData["Title"] = "Thay đổi mật khẩu";
                return View("Views/Admin/Home/ChangePassword.cshtml");
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }

        [Route("ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword(string current_password, string new_password, string verify_password)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                if (!string.IsNullOrEmpty(current_password) && !string.IsNullOrEmpty(new_password) && !string.IsNullOrEmpty(verify_password))
                {
                    string md5_password = "";
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string change = Funtions_Global.GetMd5Hash(md5Hash, current_password);
                        md5_password = change;
                    }
                    if (md5_password == Funtions_Global.GetSsAdmin(HttpContext.Session, "Password"))
                    {
                        if (new_password == verify_password)
                        {
                            Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$");

                            if (regex.IsMatch(verify_password))
                            {
                                string new_md5_password = "";
                                using (MD5 md5Hash = MD5.Create())
                                {
                                    string new_change = Funtions_Global.GetMd5Hash(md5Hash, verify_password);
                                    new_md5_password = new_change;
                                }
                                var model = _db.Users.FirstOrDefault(u => u.Username == Funtions_Global.GetSsAdmin(HttpContext.Session, "Username"));
                                if (model != null)
                                {
                                    model.Password = new_md5_password;
                                    _db.SaveChanges();
                                }

                                return RedirectToAction("LogOut", "Login");
                            }
                            else
                            {
                                string error = "Mật khẩu từ phải có ít nhất 4 ký tự và không quá 20 ký tự, bao gồm ít nhất 1 chữ cái viết hoa, 1 chữ cái viết thường và một chữ số ";
                                ViewData["Title"] = "Thay đổi mật khẩu";
                                ViewData["current_password"] = current_password;
                                ViewData["new_password"] = new_password;
                                ViewData["verify_password"] = verify_password;
                                ModelState.AddModelError("error", error);
                                return View("Views/Admin/Home/ChangePassword.cshtml");
                            }
                        }
                        else
                        {
                            ViewData["Title"] = "Thay đổi mật khẩu";
                            ModelState.AddModelError("error", "Mật khẩu mới và mật khẩu xác thực không trùng nhau");
                            ViewData["current_password"] = current_password;
                            ViewData["new_password"] = new_password;
                            ViewData["verify_password"] = verify_password;
                            return View("Views/Admin/Home/ChangePassword.cshtml");
                        }
                    }
                    else
                    {
                        ViewData["Title"] = "Thay đổi mật khẩu";
                        ModelState.AddModelError("error", "Mật khẩu hiện tại không đúng");
                        ViewData["current_password"] = current_password;
                        ViewData["new_password"] = new_password;
                        ViewData["verify_password"] = verify_password;
                        return View("Views/Admin/Home/ChangePassword.cshtml");
                    }
                }
                else
                {
                    ViewData["Title"] = "Thay đổi mật khẩu";
                    ModelState.AddModelError("error", "Thông tin không được bỏ trống");
                    ViewData["current_password"] = current_password;
                    ViewData["new_password"] = new_password;
                    ViewData["verify_password"] = verify_password;
                    return View("Views/Admin/Home/ChangePassword.cshtml");
                }
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }

        [HttpGet("ThemeSettings")]
        public IActionResult ThemeSettings()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
                {
                    var model = _db.Users.FirstOrDefault(t => t.Username == Funtions_Global.GetSsAdmin(HttpContext.Session, "Username"));
                    ViewData["Title"] = "Quản lý giao diện hiển thị";

                    ViewData["MenuLv1"] = "menu_quantrihethong";
                    ViewData["MenuLv2"] = "menu_quantrihethong_themesetting";
                    return View("Views/Admin/Home/ThemeSettings.cshtml", model);
                }
                else
                {
                    return View("Views/Admin/Error/SessionOut.cshtml");
                }
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }

        [HttpPost]
        public IActionResult UpdateTheme(Users requests)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SsAdmin")))
            {
                var model = _db.Users.FirstOrDefault(t => t.Id == requests.Id);
                if (model != null)
                {
                    model.Menu = requests.Menu;
                    model.Theme = requests.Theme;
                    model.Content = requests.Content;
                    _db.Users.Update(model);
                    _db.SaveChanges();

                    return RedirectToAction("LogOut", "Auth");
                }
                else
                {
                    return View("Views/Admin/Error/SessionOut.cshtml");
                }
            }
            else
            {
                return View("Views/Admin/Error/SessionOut.cshtml");
            }
        }
    }
}