using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Controllers
{
    [Authorize(Roles ="Admin,User")]
    public class ContactController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

       

        private readonly AppDbContext _context;
        public ContactController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            var autenticatedUser = await _userManager.FindByNameAsync(User.Identity.Name);
            contact.Name = autenticatedUser.Name + " " + autenticatedUser.Surname;
            contact.Email = autenticatedUser.Email;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
