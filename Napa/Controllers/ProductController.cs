using Microsoft.AspNetCore.Mvc;
using Napa.Models;
using Napa.Services;
using Napa.ViewModels;

namespace Napa.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IUserService _user;

        public ProductController(IProductService service, IUserService user)
        {
            _service = service;
            _user = user;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAll();
            return View(product);
        }
        public IActionResult Create()
        {
            return View(new ProductVM());
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Quantiy,Price")]Product products)
        {
            if (!ModelState.IsValid)
            {
                return View(products);
            }
            await _service.InsertAsync(products);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetAsync(id);
            if(product == null) return View("Error");
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _service.GetAsync(id);
            if(product == null) return View("NotFound");
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Quantiy,Price")]Product products)
        {
            if (!ModelState.IsValid)
            {
                return View(products);
            }
            await _service.UpdateAsync(products);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetAsync(id);
            if(product == null) return View("NotFound");
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,Title,Quantiy,Price")]Product products)
        {
            var product = await _service.GetAsync(id);
            if(product == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
