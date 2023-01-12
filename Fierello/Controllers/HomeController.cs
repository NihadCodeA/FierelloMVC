using Fierello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fierello.Controllers
{
    public class HomeController : Controller
    {
        private readonly FierrelloDB _context;
        public HomeController(FierrelloDB context) { 
        _context= context;
        }
        public IActionResult Index()
        {
            List<Product> products =_context.Products.Include(x=>x.Category).ToList();
            return View();
        }
    }
}
