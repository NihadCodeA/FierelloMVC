using Fierello.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace Fierello.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly FierrelloDB _context;
        public FooterViewComponent(FierrelloDB context) 
        {
        _context= context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products =_context.Products.ToList();
            return View(await Task.FromResult(products));
        }
    }
}
