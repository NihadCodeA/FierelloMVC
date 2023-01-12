using Fierello.Helpers;
using Fierello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Fierello.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly FierrelloDB _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(FierrelloDB context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> list = _context.Sliders.Include(x=>x.SliderImages).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if(slider == null) return View("Error");
            if (!ModelState.IsValid) return View();
            if (slider.SliderImageFiles!=null)
            {
                foreach (IFormFile file in slider.SliderImages)
                {
                    SliderImages sliderImage = new SliderImages
                    {
                        Slider = slider,
                        ImgUrl = FileManager.SaveFile(_env.WebRootPath, "uploads/sliders", file)
                    };
                    _context.SliderImages.Add(sliderImage);
                }
            }
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
