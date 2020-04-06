using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using InstemDb.Controllers.Models;
using InstemDb.Services;
using InstemDb.Services.Models.Carousel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstemDb.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarouselService _carouselService;

        public HomeController(ILogger<HomeController> logger, ICarouselService carouselService)
        {
            _logger = logger;
            _carouselService = carouselService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy() => View(new PrivacyViewModel
        {
            Username = User.Identity.Name
        });

        public async Task<IEnumerable<CarouselServiceModel>> GetCarouselData(int? year)
        {
            return await _carouselService.GetCarouselData(year);
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}
