using Microsoft.AspNetCore.Mvc;
using Napa.Services;

namespace Napa.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _service.GetAll();
            return View(product);
        }
    }
}