using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstemDb.Data;
using InstemDb.Services.Models.Carousel;
using Microsoft.EntityFrameworkCore;

namespace InstemDb.Services.Implementation
{

    public class CarouselService : ICarouselService
    {
        private const int FirstMovieEverMade = 1888;

        private readonly InstemDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarouselService(InstemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarouselServiceModel>> GetCarouselData(int? year)
        {
            if (!year.HasValue)
            {
                year = DateTime.UtcNow.Year;
            }

            var result = await GetData(year);

            while ((!result.Any() || result.Count() < 4) && year > FirstMovieEverMade)
            {
                year--;
                result = await GetData(year);
            }

            return result;
        }

        private async Task<IEnumerable<CarouselServiceModel>> GetData(int? year)
        {
            return await _dbContext.Movies.Where(x => x.Year == year)
                .OrderBy(r => Guid.NewGuid())
                .Take(4)
                .ProjectTo<CarouselServiceModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }

}