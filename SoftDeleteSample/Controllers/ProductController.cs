using Microsoft.AspNetCore.Mvc;
using SoftDeleteSample.Data;
using System;
using System.Linq;

namespace SoftDeleteSample.Controllers
{
    public class ProductController : Controller
    {
        SoftDeleteDbContext softDeleteDbContext;

        public ProductController(SoftDeleteDbContext softDeleteDbContext)
        {
            this.softDeleteDbContext = softDeleteDbContext;
        }

        public IActionResult Index()
        {
            var prodcuts = softDeleteDbContext.Products.ToList();
            return View(prodcuts);
        }
        [HttpPost]
        public IActionResult delete(int id)
        {
            var prodcut = softDeleteDbContext.Products.SingleOrDefault(x => x.Id == id);
            if (prodcut != null)
            {
                softDeleteDbContext.Products.Remove(prodcut);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
