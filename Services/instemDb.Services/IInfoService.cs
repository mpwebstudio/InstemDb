using System.Threading.Tasks;
using InstemDb.Services.Models.Info;

namespace InstemDb.Services
{
    public interface IInfoService
    {
        Task<MovieInfoResponseModel> MovieInfo(int id);
        Task<ActorInfoResponseModel> ActorInfo(int id);
        Task<DirectorInfoResponseModel> DirectorInfo(int id);
    }
}
