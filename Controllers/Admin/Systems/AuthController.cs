using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLViecLam.Data;
using QLViecLam.Helper;
using QLViecLam.Models.Admin.Systems;
using System.Security.Cryptography;

namespace QLViecLam.Controllers.Admin.Systems
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("Login")]
        public IActionResult Login(string Username)
        {           
            string? banquyen = "LifeSoftwave";
           
            ViewData["Title"] = "Đăng nhập hệ thống";
            ViewData["Username"] = Username;
            ViewData["BanQuyen"] = banquyen;
            return View("Views/Admin/Systems/Auth/Login.cshtml");
        }

        [HttpPost("SigIn")]
        public IActionResult SignIn(string username, string password)
        {
            if (username != null && password != null)
            {
                var model = _db.Users.FirstOrDefault(u => u.Username == username);

                if (model != null)
                {
                    if (model.Status == "Lock")
                    {
                        ModelState.AddModelError("error", "Tài khoản đã bị khóa. Liên hệ với quản trị hệ thống !!!");
                        ViewData["username"] = username;
                        ViewData["password"] = password;
                        return View("Views/Admin/Systems/Auth/Login.cshtml");
                    }
                    else
                    {
                        string md5_password = "";
                        using (MD5 md5Hash = MD5.Create())
                        {
                            string change = Funtions_Global.GetMd5Hash(md5Hash, password);
                            md5_password = change;
                        }
                        if (md5_password == model.Password)
                        {
                            model.CountLogin = 0;
                            _db.Users.Update(model);
                            _db.SaveChanges();
                            
                            HttpContext.Session.SetString("SsAdmin", JsonConvert.SerializeObject(model));
                            
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            //int locklogin = _db.SystemInfo.OrderBy(t => t.Id).First().LoginLock;
                            int count = model.CountLogin + 1;
                            if (count == 5)
                            {
                                model.Status = "Lock";
                            }
                            else
                            {
                                model.CountLogin = count;
                            }
                            _db.Users.Update(model);
                            _db.SaveChanges();
                            ViewData["username"] = username;
                            ModelState.AddModelError("error", "Mật khẩu truy cập không đúng!!!(" + count + "/5)");
                            ViewData["Title"] = "Login";
                            return View("Views/Admin/Systems/Auth/Login.cshtml");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("error", "Tài khoản/Mật khẩu truy cập không đúng !!!");
                    ViewData["Title"] = "Login";
                    return View("Views/Admin/Systems/Auth/Login.cshtml");
                }
            }
            else
            {
                ModelState.AddModelError("error", "Tài khoản/Mật khẩu truy cập không được để trống !!!");
                ViewData["Title"] = "Login";
                return View("Views/Admin/Systems/Auth/Login.cshtml");
            }
        }

        [HttpGet("LogOut")]
        public IActionResult LogOut()
        {
            //HttpContext.Session.Remove("Permission");
            HttpContext.Session.Remove("SsAdmin");
            return RedirectToAction("Login", "Auth");
        }
    }
}
