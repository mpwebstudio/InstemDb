using System.Threading.Tasks;
using InstemDb.Services;
using InstemDb.Services.Models.Search;
using Microsoft.AspNetCore.Mvc;

namespace InstemDb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchRequestModel searchRequestModel)
        {
            var result = await _searchService.Search(searchRequestModel);
            return View(result);
        }
    }
}
