using CourseApp.Areas.Admin.Models.AboutDTOs;
using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {

        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Abouts.FirstOrDefault();
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
        public IActionResult CreateAbout()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO aboutDto)
        {
            if (ModelState.IsValid)
            {
                About about = new About();

                about.AboutTitle = aboutDto.AboutTitle;
                about.AboutDescription = aboutDto.AboutDescription;
                about.Image = UploadFile(aboutDto.Image);


                _context.Abouts.Add(about);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutDto);
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var aboutValue = _context.Abouts.Find(id);
            var getAbout = new UpdateAboutDTO
            {

                AboutId = aboutValue.AboutId,
                AboutDescription = aboutValue.AboutDescription,
                AboutTitle = aboutValue.AboutTitle,
            };

            return View(getAbout);
        }
        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            if (ModelState.IsValid)
            {
                var values = _context.Abouts.Find(updateAboutDTO.AboutId);

                values.AboutId = updateAboutDTO.AboutId;
                values.Image = updateAboutDTO.Image != null ? UploadFile(updateAboutDTO.Image) : values.Image;
                values.AboutDescription = updateAboutDTO.AboutDescription;
                values.AboutTitle = updateAboutDTO.AboutTitle;
                _context.Abouts.Update(values);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateAboutDTO);
        }

        public IActionResult DeleteAbout(int id)
        {
            var values = _context.Abouts.Find(id);
            _context.Abouts.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private string UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/AboutImagesFiles/",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/ImagesFiles/AboutImagesFiles/" + file.FileName;
        }
    }
}