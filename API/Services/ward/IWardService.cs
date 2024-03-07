using API.Dtos.Ward;

namespace API.Services.ward
{
    public interface IWardService
    {
        Task<WardResponse> AddWard(WardRequest wardRequest);
        Task<WardResponse> GetWard(int id);
        Task<List<WardResponse>> GetWards();
        Task<List<WardResponse>> GetWardsByDistrictID(int id);
    }
}