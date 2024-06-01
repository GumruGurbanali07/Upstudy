using CourseApp.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {

        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = _context.Contacts.Find(id);
            _context.Contacts.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}