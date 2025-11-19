using SmoothieShop.Data.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Core.Contracts
{
    public interface ISearchService
    {
        SearchResultModel Search(string query);
    }
}
