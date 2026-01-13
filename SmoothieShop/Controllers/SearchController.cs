using Microsoft.AspNetCore.Mvc;
using SmoothieShop.Core.Contracts;

namespace SmoothieShop.Controllers
{
    /// <summary>
    /// Controls Search functionalities.
    /// </summary>
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

            TempData["message"] = $"Here you can search";

            return View(results);
        }
    }
}
