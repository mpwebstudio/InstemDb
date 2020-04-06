using System.Threading.Tasks;
using InstemDb.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstemDb.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InfoController : Controller
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet]
        [Route("GetMovieInfo/{id:int}")]
        public async Task<IActionResult> MovieInfo(int id)
        {
            return Ok(await _infoService.MovieInfo(id));
        }

        [HttpGet]
        [Route("GetActorInfo/{id:int}")]
        public async Task<IActionResult> ActorInfo(int id)
        {
            return Ok(await _infoService.ActorInfo(id));
        }

        [HttpGet]
        [Route("GetDirectorInfo/{id:int}")]
        public async Task<IActionResult> DirectorInfo(int id)
        {
            return Ok(await _infoService.DirectorInfo(id));
        }
    }
}
