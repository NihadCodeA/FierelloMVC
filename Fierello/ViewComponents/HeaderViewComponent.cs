using Fierello.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace Fierello.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly FierrelloDB _context;
        public HeaderViewComponent(FierrelloDB context) 
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
