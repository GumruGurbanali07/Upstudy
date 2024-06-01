
using CourseApp.Areas.Admin.Models.CourseCategoryDTOs;
using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly AppDbContext _context;
        public BlogCategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.BlogCategories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBlogCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlogCategory(BlogCategory blogCategory)
        {
            blogCategory.IsDeleted = false;
            var categoryName = _context.BlogCategories.Where(x => x.Name == blogCategory.Name).Select(x => x.Name).FirstOrDefault();
            if (categoryName != blogCategory.Name)
            {
                _context.BlogCategories.Add(blogCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Name", "This Category is already exist!");
            }
            return View(blogCategory);

        }

        [HttpGet]
        public IActionResult UpdateBlogCategory(int id)
        {
            var value = _context.BlogCategories.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBlogCategory(BlogCategory blogCategory)
        {
            var categoryName = _context.BlogCategories.Where(x => x.Name == blogCategory.Name).Select(x => x.Name).FirstOrDefault();
            if (categoryName != blogCategory.Name)
            {
                _context.BlogCategories.Update(blogCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Name", "This Category is already exist!");
            }
          return View(blogCategory);
        }

        public IActionResult DeleteBlogCategory(int id)
        {
            var values = _context.BlogCategories.Find(id);
            _context.BlogCategories.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            var values = _context.BlogCategories.Find(id);
            values.IsDeleted = true;
            _context.BlogCategories.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            var values = _context.BlogCategories.Find(id);
            values.IsDeleted = false;
            _context.BlogCategories.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
