using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstemDb.Data;
using InstemDb.Services.Models.Search;
using Microsoft.EntityFrameworkCore;

namespace InstemDb.Services.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly InstemDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchService(InstemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchResponseModel>> Search(SearchRequestModel request)
        {
            return request.SearchParam.ToLower() switch
            {
                "title" => await SearchByTitle(request.SearchTerm),
                "director" => await SearchByDirectorName(request.SearchTerm),
                "actor" => await SearchByActorName(request.SearchTerm),
                _ => null,
            };
        }

        private async Task<IEnumerable<SearchResponseModel>> SearchByTitle(string title)
        {
            return await _dbContext.Movies
                .Where(x => x.Title.Contains(title))
                .ProjectTo<SearchResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private async Task<IEnumerable<SearchResponseModel>> SearchByDirectorName(string directorName)
        {
            return await _dbContext.Directors
                .Where(x => x.Name.Contains(directorName))
                .ProjectTo<SearchResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private async Task<IEnumerable<SearchResponseModel>> SearchByActorName(string actorName)
        {
            return await _dbContext.Actors
                .Where(x => x.Name.Contains(actorName))
                .ProjectTo<SearchResponseModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
