using CricBook.Models;
using CricBook.Models.Repository;
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
            List<Field> fields = new List<Field>();
            fields = FieldRepository.GetFields();


            List<FieldComponentViewModel> fieldViewModels = fields.Select(field => new FieldComponentViewModel
            {
                PrimaryImage = field.PrimaryImage,
                City = field.City,
                Address = field.Address,
                OpeningTime = field.OpeningTime,
                ClosingTime = field.ClosingTime,
                Id = field.Id
            }).ToList();

            string layout = Request.Cookies["UserId"] != null ? "_Layout2" : "_Layout";
            ViewData["Layout"] = $"~/Views/Shared/{layout}.cshtml";

            return View(fieldViewModels);
        }

        public IActionResult RegisterField()
        {
            return View();
        }

        public IActionResult Fields()
        {
            return View();
        }

        public IActionResult AllFields()
        {
            CricbookContext cx = new CricbookContext();
            List<Field> fields = cx.Fields.ToList();

            List<FieldComponentViewModel> fieldViewModels = fields.Select(field => new FieldComponentViewModel
            {
                PrimaryImage = field.PrimaryImage,
                City = field.City,
                Address = field.Address,
                OpeningTime = field.OpeningTime,
                ClosingTime = field.ClosingTime,
                Id = field.Id
            }).ToList();


            string layout = Request.Cookies["UserId"] != null ? "_Layout2" : "_Layout";
            ViewData["Layout"] = $"~/Views/Shared/{layout}.cshtml";

            return View(fieldViewModels);
        }
    }
}