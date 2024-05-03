using Microsoft.AspNetCore.Mvc;
using RelationInModels.Models;
using System.Diagnostics;

namespace RelationInModels.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
