using CricBook.Models;
using CricBook.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace CricBook.Controllers
{
    public class HostController: Controller
    {
        public IActionResult RegisterField()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterField(Field f, IFormFile primaryImage, IFormFile optionalImage1, IFormFile optionalImage2)
        {
            Console.WriteLine(f.PrimaryImage);

            using (var memoryStream = new MemoryStream())
            {
                primaryImage.CopyTo(memoryStream);
                f.PrimaryImage = memoryStream.ToArray();
            }

            Console.WriteLine("....");
            string userId = Request.Cookies["UserId"];

            Console.WriteLine("....");
            Console.WriteLine(userId);
            Console.WriteLine("....");

            f.HostId = int.Parse(userId);

            if (optionalImage1 != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    optionalImage1.CopyTo(memoryStream);
                    f.OptionalImage1 = memoryStream.ToArray();
                }
            }

            if (optionalImage2 != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    optionalImage2.CopyTo(memoryStream);
                    f.OptionalImage2 = memoryStream.ToArray();
                }
            }

            CricbookContext cx = new CricbookContext();
            cx.Fields.Add(f);
            cx.SaveChanges();
            return RedirectToAction("Dashboard", "Host");
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }

    
}
