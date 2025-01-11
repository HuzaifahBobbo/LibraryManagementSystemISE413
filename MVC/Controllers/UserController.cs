using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using LibraryManagementSystem.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly LibraryContext _context;

        public UsersController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var loggedInUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
                
                if (loggedInUser != null)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            return View(user);
        }
    }
}
