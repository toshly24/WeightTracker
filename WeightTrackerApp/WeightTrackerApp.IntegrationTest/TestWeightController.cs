using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WeightTrackerApp.Contact;
using WeightTrackerApp.Controllers;
using WeightTrackerApp.Data;
using WeightTrackerApp.Models;
using WeightTrackerApp.ViewModels;

namespace WeightTrackerApp.IntegrationTest
{
    public class TestWeightController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        [Fact]
        public void TestIndex()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            IActionResult result;
            using (ApplicationDbContext applicationDbContext = new(optionsBuilder.Options))
            {
                result = new WeightController(applicationDbContext, _userManager, _unitOfWork).Index();
            }

            var okResult = Assert.IsType<OkObjectResult>(result);
            var weights = Assert.IsType<List<Weight>>(okResult.Value);
            var note = Assert.Single(weights);

            Assert.NotNull(note);
        }

        [Fact]
        public void TestCreateGetMethod()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            WeightViewModel weight = new WeightViewModel();

            IActionResult result;
            using (ApplicationDbContext applicationDbContext = new(optionsBuilder.Options))
            {
                result = new WeightController(applicationDbContext, _userManager, _unitOfWork).Create(weight);
            }

            var okResult = Assert.IsType<OkObjectResult>(result);
            var weights = Assert.IsType<List<Weight>>(okResult.Value);
            var note = Assert.Single(weights);

            Assert.NotNull(note);
        }
    }
}