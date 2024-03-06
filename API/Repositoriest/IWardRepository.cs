using API.Dtos.Ward;

namespace API.Repositoriest
{
    public interface IWardRepository
    {
        Task<WardResponse> AddWard(WardRequest wardRequest);
        Task<WardResponse> GetWard(int id);
        Task<List<WardResponse>> GetWards();
        Task<List<WardResponse>> GetWardsByDistrictID(int id);
    }
}