using CourseApp.Areas.Admin.Models.BlogDTOs;
using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Blogs.Include(x => x.BlogCategory).Include(x => x.Teacher).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBlog()
        {
            //bu structure dropdown list-de teachers classinda olan datalarin siyahilanmasi ucun istifade olunur
            List<SelectListItem> teacherValues = (from x in _context.Teachers.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.TeacherName,
                                                      Value = x.TeacherId.ToString(),

                                                  }).ToList();
            ViewBag.Teachers = teacherValues;

            List<SelectListItem> categoryValues = (from x in _context.BlogCategories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.BlogCategoryId.ToString(),

                                                   }).ToList();
            ViewBag.BlogCategory = categoryValues;

            return View();
        }

        [HttpPost]
        public IActionResult CreateBlog(CreateBlogDTO blogDto)
        {
            if (ModelState.IsValid)
            {
                Blog blog = new Blog();
                blog.BlogTitle = blogDto.BlogTitle;
               blog.CreatedDate= DateTime.Parse(DateTime.Now.ToShortTimeString());
                blog.BlogCategoryId = blogDto.BlogCategoryId;
                blog.TeacherId = blogDto.TeacherId;
                blog.Image = UploadFile(blogDto.Image);
                blog.IsActive = false;
                blog.Description = blogDto.Description;
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogDto);
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blogValue = _context.Blogs.Find(id);

            List<SelectListItem> teacherValues = (from x in _context.Teachers.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.TeacherName,
                                                      Value = x.TeacherId.ToString(),

                                                  }).ToList();
            ViewBag.Teachers = teacherValues;

            List<SelectListItem> categoryValues = (from x in _context.BlogCategories.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.BlogCategoryId.ToString(),

                                                   }).ToList();
            ViewBag.BlogCategory = categoryValues;
            var getBlog = new UpdateBlogDTO
            {
                BlogId = blogValue.BlogId,
                BlogTitle = blogValue.BlogTitle,
                Description = blogValue.Description,
                BlogCategoryId = blogValue.BlogCategoryId,
                IsActive = blogValue.IsActive,
                TeacherId = blogValue.TeacherId,

            };

            return View(getBlog);
        }
        [HttpPost]
        public IActionResult UpdateBlog(UpdateBlogDTO updateBlogDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Blogs.Find(updateBlogDTO.BlogId);
                values.BlogTitle = updateBlogDTO.BlogTitle;
                values.Description = updateBlogDTO.Description;
                values.BlogCategoryId = updateBlogDTO.BlogCategoryId;
                values.BlogId = updateBlogDTO.BlogId;
                values.Image = updateBlogDTO.Image != null ? UploadFile(updateBlogDTO.Image) : values.Image;
                values.CreatedDate = updateBlogDTO.CreatedDate;
                values.IsActive = values.IsActive;
                values.TeacherId = updateBlogDTO.TeacherId;
                values.BlogCategoryId = updateBlogDTO.BlogCategoryId;
                _context.Blogs.Update(values);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateBlogDTO);
        }

        public IActionResult DeleteBlog(int id)
        {
            var values = _context.Blogs.Find(id);
            _context.Blogs.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToTrue(int id)
        {
            var values = _context.Blogs.Find(id);
            values.IsActive = true;
            _context.Blogs.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            var values = _context.Blogs.Find(id);
            values.IsActive = false;
            _context.Blogs.Update(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/BlogImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/BlogImagesFiles/" + file.FileName;
        }
    }
}
