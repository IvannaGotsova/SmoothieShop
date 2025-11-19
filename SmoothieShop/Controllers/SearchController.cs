using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;

namespace SmoothieShop.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Index(string query)
        {
            var results = searchService.Search(query);

            return View(results);
        }
    }
}
