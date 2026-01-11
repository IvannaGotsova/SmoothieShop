using SmoothieShop.Data.Models.SearchModels;

namespace SmoothieShop.Core.Contracts
{
    /// <summary>
    /// Holds Interface for Search functionality.
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// This method is used for search functionality.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        SearchResultModel Search(string query);
    }
}