using CricBook.Models;
using CricBook.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace CricBook.Controllers
{
    public class PlayerController : Controller
    {
        int id = 0;
        [HttpPost]
        public IActionResult Visit()
        {
            if (Request.Cookies["UserId"] != null)
            {
                string layout = "_Layout2";
                ViewData["Layout"] = $"~/Views/Shared/{layout}.cshtml";
                string temp = Request.Form["Id"].ToString();
                Console.WriteLine(temp);
                id = int.Parse(temp);
                Console.WriteLine($"Id in Visit: {id}");

                Field f = FieldRepository.GetField(id);

                return View(f);
            }
            else
            {
                return RedirectToAction("LoginPlayer", "Auth");
            }
        }
        public IActionResult Book()
        {
            if (Request.Cookies["UserId"] != null)
            {
                string layout = "_Layout2";
                ViewData["Layout"] = $"~/Views/Shared/{layout}.cshtml";

                Field f = FieldRepository.GetField(id);

                return View(f);
            }
            else
            {
                return RedirectToAction("LoginPlayer", "Auth");
            }
        }
        [HttpPost]
        public IActionResult Slot()
        {
            if (Request.Cookies["UserId"] != null)
            {
                string layout = "_Layout2";
                ViewData["Layout"] = $"~/Views/Shared/{layout}.cshtml";

                bool [] availableSlots = PlayerRepository.getSlots(DateTime.Parse(Request.Form["date"]));

                return View(availableSlots);
            }
            else
            {
                return RedirectToAction("LoginPlayer", "Auth");
            }
        }

        [HttpPost]
        public IActionResult Dashboard(bool[] boolValues)
        {
            if (Request.Cookies["UserId"] != null)
            {
                string layout = "_Layout2";
                ViewData["Layout"] = $"~/Views/Shared/{layout}.cshtml";

                return View();
            }
            else
            {
                return RedirectToAction("LoginPlayer", "Auth");
            }
        }
    }
}
