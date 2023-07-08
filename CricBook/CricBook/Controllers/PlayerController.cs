using CricBook.Models;
using CricBook.Models.Repository;
using Microsoft.AspNetCore.Mvc;

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

                id = int.Parse(Request.Form["id"]);
                Field f = authentication.GetField(id);

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

                Field f = authentication.GetField(id);

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

                bool [] availableSlots = authentication.getSlots(DateTime.Parse(Request.Form["date"]));

                availableSlots[2] = false;

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
