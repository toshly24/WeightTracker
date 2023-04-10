using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeightTrackerApp.Contact;
using WeightTrackerApp.Data;
using WeightTrackerApp.Models;
using WeightTrackerApp.ViewModels;

namespace WeightTrackerApp.Controllers
{
    public class WeightController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public WeightController(ApplicationDbContext context, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _context = context;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var weight = _unitOfWork.Weight.GetAllBy(n => n.UserId == userId);
            return View(weight);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WeightViewModel model)
        {
            model.UserId = _userManager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                var squerHeight = model.HeightValue * model.HeightValue;
                var bim = Math.Round(model.WeightValue / squerHeight);

                var note = new Weight()
                {
                    WeightValue = model.WeightValue,
                    HeightValue = model.HeightValue,
                    BIMValue = bim,
                    Tag = model.Tag,
                    CreatedDate = model.CreatedDate,
                    ModifiedDate = DateTime.Now,
                    UserId = model.UserId
                };

                _unitOfWork.Weight.Create(note);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index), "Weight");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var weight = _unitOfWork.Weight.GetBy(n => n.Id == id);

            if (weight.UserId == userId)
            {
                var model = new WeightViewModel()
                {
                    Id = weight.Id,
                    WeightValue = weight.WeightValue,
                    HeightValue = weight.HeightValue,
                    BIMValue = weight.BIMValue,
                    Tag = weight.Tag,
                    CreatedDate = weight.CreatedDate,
                    ModifiedDate = weight.ModifiedDate,
                    UserId = userId
                };

                return View(model);
            }
            else
            {
                return Content("You are not authorized");
            }
        }

        [HttpPost]
        public IActionResult Edit(WeightViewModel model)
        {
            if (ModelState.IsValid)
            {
                var squerHeight = model.HeightValue * model.HeightValue;
                var bim = Math.Round(model.WeightValue / squerHeight);

                var userId = _userManager.GetUserId(HttpContext.User);

                if (model.UserId == userId)
                {
                    var weight = new Weight
                    {
                        Id = model.Id,
                        WeightValue = model.WeightValue,
                        HeightValue = model.HeightValue,
                        BIMValue = bim,
                        Tag = model.Tag,
                        CreatedDate = model.CreatedDate,
                        ModifiedDate = DateTime.Now,
                        UserId = model.UserId,                        
                    };

                    _unitOfWork.Weight.Update(weight);
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content("You are not authorized");
                }
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return Content("Weight Id is null");
            }

            var userId = _userManager.GetUserId(HttpContext.User);
            var weight = _unitOfWork.Weight.GetBy(n => n.Id == id);
            
            if (weight.UserId == userId)
            {
                _unitOfWork.Weight.Delete(id);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return Content("You are not authorized");
        }
    }
}