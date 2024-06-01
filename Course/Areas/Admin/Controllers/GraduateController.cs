using CourseApp.Areas.Admin.Models.GraduateDTO;
using CourseApp.Areas.Admin.Models.GraduateDTOs;
using CourseApp.Context;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GraduateController : Controller
	{
		private readonly AppDbContext _context;
		public GraduateController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var values = _context.Graduates.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateGraduate()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateGraduate(CreateGraduateDTO graduateDto)
		{
			if (ModelState.IsValid)
			{
				Graduate graduate = new Graduate();
				graduate.Name = graduateDto.Name;
				graduate.IsActive = false;
				graduate.Description = graduateDto.Description;
				graduate.Comment = graduateDto.Comment;
				graduate.CurrentWork = graduateDto.CurrentWork;
				graduate.Image = UploadFile(graduateDto.Image);
				_context.Graduates.Add(graduate);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(graduateDto);
		}

		[HttpGet]
		public IActionResult UpdateGraduate(int id)
		{
			var graduateValue = _context.Graduates.Find(id);
			var getGraduate = new UpdateGraduateDTO
			{
				Description = graduateValue.Description,
				Comment = graduateValue.Comment,
				CurrentWork = graduateValue.CurrentWork,
				Name = graduateValue.Name,
				IsActive = graduateValue.IsActive,
				GraduateId = graduateValue.GraduateId,

			};

			return View(getGraduate);
		}



		[HttpPost]
		public IActionResult UpdateGraduate(UpdateGraduateDTO updateGraduateDTO)
		{
			if (ModelState.IsValid)
			{
				var values = _context.Graduates.Find(updateGraduateDTO.GraduateId);
				values.Name = updateGraduateDTO.Name;
				values.GraduateId = updateGraduateDTO.GraduateId;
				values.Image = updateGraduateDTO.Image != null ? UploadFile(updateGraduateDTO.Image) : values.Image;
				values.IsActive = values.IsActive;
				values.Comment = updateGraduateDTO.Comment;
				values.CurrentWork = updateGraduateDTO.CurrentWork;
				_context.Graduates.Update(values);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(updateGraduateDTO);
		}

		public IActionResult DeleteGraduate(int id)
		{
			var values = _context.Graduates.Find(id);
			_context.Graduates.Remove(values);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult ChangeStatusToTrue(int id)
		{
			var values = _context.Graduates.Find(id);
			values.IsActive = true;
			_context.Graduates.Update(values);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult ChangeStatusToFalse(int id)
		{
			var values = _context.Graduates.Find(id);
			values.IsActive = false;
			_context.Graduates.Update(values);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		private string UploadFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return null;

			var path = Path.Combine(
						Directory.GetCurrentDirectory(), "wwwroot/ImagesFiles/GraduateImagesFiles/",
						file.FileName);

			using (var stream = new FileStream(path, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			return "/ImagesFiles/GraduateImagesFiles/" + file.FileName;
		}
	}
}
