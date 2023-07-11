using CricBook.Models;
using CricBook.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace CricBook.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LoginPlayer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPlayer1()
        {
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            CricbookContext cx = new CricbookContext();
            User user = cx.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                if (user.Password == password)
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddDays(7),
                        IsEssential = true,
                        HttpOnly = true
                    };

                    Response.Cookies.Append("UserId", $"{user.Id}", cookieOptions);

                    string userId = Request.Cookies["UserId"];

                    var layout = "_Layout2";
                    return RedirectToAction("Index", "Home", new { layout = layout });
                }
            }
            return RedirectToAction("LoginPlayer", "Auth");
        }

        public IActionResult LoginHost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginHost1()
        {
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            CricbookContext cx = new CricbookContext();
            User user = cx.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                if (user.Password == password)
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddDays(7),
                        IsEssential = true,
                        HttpOnly = true
                    };

                    Response.Cookies.Append("UserId", $"{user.Id}", cookieOptions);

                    string userId = Request.Cookies["UserId"];

                    var layout = "_Layout2";
                    return RedirectToAction("Index", "Home", new { layout = layout });
                }
            }
            return RedirectToAction("LoginHost", "Auth");
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignupPlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignupPlayer(User u)
        {
            CricbookContext cx = new CricbookContext();
            u.Type = "Player";
            cx.Users.Add(u);
            cx.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult SignupHost()
        {
            return View();
        }

        public IActionResult Fields()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserId");

            return RedirectToAction("Index", "Home");
        }
    }
}