using System.Collections.Generic;
using System.Threading.Tasks;
using InstemDb.Services.Models.Search;

namespace InstemDb.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<SearchResponseModel>> Search(SearchRequestModel request);
    }
}
