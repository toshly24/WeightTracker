using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WeightTrackerApp.Contact;
using WeightTrackerApp.Controllers;
using WeightTrackerApp.Data;
using WeightTrackerApp.Models;

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
            var notes = Assert.IsType<List<Weight>>(okResult.Value);
            var note = Assert.Single(notes);

            Assert.NotNull(note);
        }
    }
}