using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstemDb.Data;
using InstemDb.Services.Models.Info;
using Microsoft.EntityFrameworkCore;

namespace InstemDb.Services.Implementation
{
    public class InfoService : IInfoService
    {
        private readonly InstemDbContext _dbContext;
        private readonly IMapper _mapper;

        public InfoService(InstemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MovieInfoResponseModel> MovieInfo(int id)
        {
            return await _dbContext.Movies
                .Where(x => x.Id == id)
                .ProjectTo<MovieInfoResponseModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<ActorInfoResponseModel> ActorInfo(int id)
        {
             return await _dbContext.Actors
                .Where(x => x.Id == id)
                .ProjectTo<ActorInfoResponseModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<DirectorInfoResponseModel> DirectorInfo(int id)
        {
            return await _dbContext.Directors
                .Where(x => x.Id == id)
                .ProjectTo<DirectorInfoResponseModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
