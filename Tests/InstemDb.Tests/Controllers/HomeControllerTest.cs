using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstemDb.Controllers;
using InstemDb.Controllers.Models;
using InstemDb.Services;
using InstemDb.Services.Models.Carousel;
using InstemDb.Tests.Extensions;
using InstemDb.Tests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace InstemDb.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public async Task HomeController_GetCarouselData_ShouldReturnExactData()
        {
            //Arrange
            var homeController = GetHomeController();

            //Act
            var result = await homeController.GetCarouselData(2020);

            //Assert
            var model = Assert.IsAssignableFrom<IEnumerable<CarouselServiceModel>>(result);
            Assert.Equal(4, model.Count());
        }

        [Fact]
        public async Task HomeController_GetCarouselData_ShouldReturnEmptyData()
        {
            //Arrange
            var homeController = GetHomeController();

            //Act
            var result = await homeController.GetCarouselData(2018);

            //Assert
            var model = Assert.IsAssignableFrom<IEnumerable<CarouselServiceModel>>(result);
            Assert.Empty(model);
        }

        [Fact]
        public void HomeController_Index_ShouldReturnViewResult()
        {
            // Arrange
            var homeController = GetHomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void HomeController_Privacy_ShouldReturnViewResultWithCorrectUsername()
        {
            // Arrange
            var homeController = GetHomeController().WithTestUser();

            // Act
            var result = homeController.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<PrivacyViewModel>(viewResult.Model);
            Assert.Equal(TestConstants.TestUsername, model.Username);
        }

        private HomeController GetHomeController(ICarouselService carouselService = null)
        {
            carouselService ??= new FakeCarouselService();

            return new HomeController(null, carouselService);
        }
    }
}
