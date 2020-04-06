using System.Threading.Tasks;
using InstemDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstemDb.Controllers
{
    public class InfoController : Controller
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public async Task<IActionResult> MovieInfo(int id)
        {
            return View(await _infoService.MovieInfo(id));
        }

        public async Task<IActionResult> ActorInfo(int id)
        {
            return View(await _infoService.ActorInfo(id));
        }

        public async Task<IActionResult> DirectorInfo(int id)
        {
            return View(await _infoService.DirectorInfo(id));
        }
    }
}
