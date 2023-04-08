using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeightTrackerApp.Contact;
using WeightTrackerApp.Controllers;
using WeightTrackerApp.Data;
using WeightTrackerApp.Models;
using WeightTrackerApp.ViewModels;

namespace WeightTrackerApp.UnitTest
{
    [TestClass]
    public class TestWeightController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        [TestMethod]
        public void TestIndex()
        {
            WeightController weightController = new WeightController(_context, _userManager, _unitOfWork);
            var result = weightController.Index() as ViewResult;
            var weights = (List<Weight>?)result?.ViewData.Model;

            Assert.Equals(weights?.Count, weights?.Count);
        }

        [TestMethod]
        public void TestCreateGetMethod()
        {
            WeightController weightController = new WeightController(_context, _userManager, _unitOfWork);
            var result = weightController.Create() as ViewResult;

            Assert.AreEqual("Create", result?.ViewName);
        }

        [TestMethod]
        public void TestCreatePostMethod()
        {
            WeightViewModel weightViewModel = new WeightViewModel();

            WeightController weightController = new WeightController(_context, _userManager, _unitOfWork);
            var result = weightController.Create(weightViewModel) as ViewResult;
            var createdWeight = (Weight?)result?.ViewData.Model;

            Assert.IsNotNull(createdWeight);
        }

        [TestMethod]
        public void TestEditGetMethod()
        {
            WeightViewModel weightViewModel = new WeightViewModel();

            WeightController weightController = new WeightController(_context, _userManager, _unitOfWork);
            var result = weightController.Edit(1) as ViewResult;
            var editWeight = (WeightViewModel?)result?.ViewData.Model;

            Assert.IsNotNull(editWeight);
        }

        [TestMethod]
        public void TestEditPostMethod()
        {
            WeightViewModel weightViewModel = new WeightViewModel();

            WeightController weightController = new WeightController(_context, _userManager, _unitOfWork);
            var result = weightController.Edit(weightViewModel) as ViewResult;
            var editWeight = (WeightViewModel?)result?.ViewData.Model;

            Assert.IsNotNull(editWeight);
        }

        [TestMethod]
        public void TestDeleteMethod()
        {
            WeightController weightController = new WeightController(_context, _userManager, _unitOfWork);
            var result = weightController.Delete(1) as ViewResult;

            Assert.Equals("Index", result.ViewName);
        }
    }
}