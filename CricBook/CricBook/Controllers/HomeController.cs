using CricBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CricBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginPlayer()
        {
            return View();
        }

        public IActionResult LoginHost()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult SignupPlayer()
        {
            return View();
        }

        public IActionResult SignupHost()
        {
            return View();
        }
    }
}