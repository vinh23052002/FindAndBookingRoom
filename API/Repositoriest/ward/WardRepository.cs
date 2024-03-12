using API.Dtos.Ward;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest.ward
{
    public class WardRepository : IWardRepository
    {
        private readonly RoomContext roomContext;
        private readonly IMapper _mapper;

        public WardRepository(RoomContext roomContext, IMapper mapper)
        {
            this.roomContext = roomContext;
            _mapper = mapper;
        }

        public async Task<List<WardResponse>> GetWards()
        {
            var wards = await roomContext.Wards
                .Include(p => p.District)
                .ThenInclude(p => p.Province)
                .Select(p => new WardResponse
                {
                    ward_id = p.ward_id,
                    ward_name = p.ward_name,
                    ward_type = p.ward_type,
                    district_id = p.District.district_id,
                    province_id = p.District.province_id,
                    lat = p.lat,
                    lng = p.lng,
                    district = p.District.district_name,
                    province = p.District.Province.province_name
                }).ToListAsync();

            return _mapper.Map<List<WardResponse>>(wards);
        }

        public async Task<WardResponse> AddWard(WardRequest wardRequest)
        {
            var ward = _mapper.Map<Ward>(wardRequest);
            roomContext.Wards.Add(ward);
            await roomContext.SaveChangesAsync();
            return _mapper.Map<WardResponse>(ward);
        }

        public async Task<WardResponse> GetWard(int id)
        {
            var ward = await roomContext.Wards
                .Include(p => p.District)
                .ThenInclude(p => p.Province)
                .Select(p => new WardResponse
                {
                    ward_id = p.ward_id,
                    ward_name = p.ward_name,
                    ward_type = p.ward_type,
                    district_id = p.district_id,
                    province_id = p.District.province_id,
                    lat = p.lat,
                    lng = p.lng,
                    district = p.District.district_name,
                    province = p.District.Province.province_name
                })
                .FirstOrDefaultAsync(x => x.ward_id == id);
            return _mapper.Map<WardResponse>(ward);
        }

        public async Task<List<WardResponse>> GetWardsByDistrictID(int id)
        {
            var wards = await roomContext.Wards.Where(x => x.district_id == id).ToListAsync();
            return _mapper.Map<List<WardResponse>>(wards);
        }

    }
}
