using Microsoft.AspNetCore.Mvc;
using Napa.Models;
using Napa.Services;

namespace Napa.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Users()
        {
            var user = await _service.GetAll();
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _service.GetAsync(id);
            if(user == null) return View("NotFound");
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteUserConfirmed(int id, [Bind("Username,Password")]User users)
        {
            var user = _service.GetAsync(id);
            if(user == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _service.GetAsync(id);
            if(user == null) return View("Error");
            return View(user);
        }

    }
}