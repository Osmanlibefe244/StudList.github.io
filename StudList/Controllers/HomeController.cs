using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudList.Models;
using System.Diagnostics;
using System.Linq;

namespace StudList.Controllers
{
    public class HomeController : Controller
    {
        ApplContext db;
        public HomeController(ApplContext context) 
        { 
            db = context;
        }


        public IActionResult Index()
        {
            return View(db.Subjects.ToList());
            ViewData["SubjectId"] = new SelectList(db.Subjects, "Id", "Name");
        }

        public IActionResult Privacy() 
        { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}