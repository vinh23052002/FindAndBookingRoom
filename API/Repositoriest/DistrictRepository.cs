using API.Dtos.District;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly RoomContext _context;
        private readonly IMapper _mapper;

        public DistrictRepository(RoomContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<DistrictResponse>> GetDistricts()
        {
            var districts = await _context.Districts.ToListAsync();
            return _mapper.Map<List<DistrictResponse>>(districts);

        }
        public async Task<DistrictResponse> GetDistrict(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            return _mapper.Map<DistrictResponse>(district);
        }
        public async Task<DistrictResponse> AddDistrict(DistrictRequest districtRequest)
        {
            var district = _mapper.Map<District>(districtRequest);
            _context.Districts.Add(district);
            await _context.SaveChangesAsync();
            return _mapper.Map<DistrictResponse>(district);
        }

        public async Task<List<DistrictResponse>> GetDistrictsByProvinceID(int id)
        {
            var districts = await _context.Districts.Where(d => d.province_id == id).ToListAsync();
            return _mapper.Map<List<DistrictResponse>>(districts);
        }
    }
}
