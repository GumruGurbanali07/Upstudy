using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactDetailController : Controller
    {

        private readonly AppDbContext _context;
        public ContactDetailController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.ContactDetails.FirstOrDefault();
            if (values != null)
            {
                return View(values);
            }
            else
            {
                return RedirectToAction("Indexx");
            }
        }

        public IActionResult Indexx()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateContactDetail()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateContactDetail(ContactDetail contactDetail)
        {
            _context.ContactDetails.Add(contactDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContactDetail(int id)
        {
            var values = _context.ContactDetails.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateContactDetail(ContactDetail contactDetail)
        {
            _context.ContactDetails.Update(contactDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContactDetail(int id)
        {
            var values = _context.ContactDetails.Find(id);
            _context.ContactDetails.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}