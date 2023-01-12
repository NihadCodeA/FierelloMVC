using Fierello.Helpers;
using Fierello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Fierello.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly FierrelloDB _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(FierrelloDB context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Product> list = _context.Products.Include(x=>x.Category).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Categories=_context.Categories.ToList();
            if (product == null) return View("Error");
            if(!ModelState.IsValid) return View();
            if(product.ImgFile!=null)
            {
                product.ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/products", product.ImgFile);
            }
            
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return View("Error");

            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            ViewBag.Categories = _context.Categories.ToList();
            if (product == null) return View("Error");
            Product existProduct = _context.Products.Find(product.Id);
            if (!ModelState.IsValid) return View();
            //FileInfo file = new FileInfo(Path.Combine(_env.WebRootPath + "uploads/producs", existProduct.ImgUrl));
            //if (file.Exists)
            //{
            //    file.Delete();
            //}

           existProduct.ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/sliders",product.ImgFile);
            
            existProduct.Price=product.Price;
            existProduct.CategoryId=product.CategoryId;
            existProduct.Name=product.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
