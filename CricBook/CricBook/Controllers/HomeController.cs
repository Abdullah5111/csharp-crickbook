using CricBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace CricBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            CricbookContext cx = new CricbookContext();
            List<Field> fields = cx.Fields.ToList();
            string layout = null;
            if (Request.Cookies["UserId"] != null)
            {
                layout = "_Layout2";
            }
            else
            {
                layout = "_Layout";
            }

            ViewData["Layout"] = $"~/Views/Shared/{layout}.cshtml";

            return View(fields);
        }
        public IActionResult RegisterField()
        {
            return View();
        }

        public IActionResult Fields()
        {
            return View();
        }
    }
}