using API.Dtos.Province;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly RoomContext _context;
        private readonly IMapper _mapper;

        public ProvinceRepository(RoomContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProvinceResponse>> GetProvinces()
        {
            var provinces = await _context.Provinces.ToListAsync();
            return _mapper.Map<List<ProvinceResponse>>(provinces);
        }
        public async Task<Province> GetProvince(int id)
        {
            return await _context.Provinces.FindAsync(id);
        }
        public async Task<ProvinceResponse> AddProvince(ProvinceRequest province)
        {
            var newProvince = _mapper.Map<Province>(province);
            _context.Provinces.Add(newProvince);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProvinceResponse>(newProvince);
        }
        public async Task<Province> UpdateProvince(int id, Province province)
        {
            _context.Entry(province).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return province;
        }
        public async Task<Province> DeleteProvince(int id)
        {
            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return null;
            }
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
            return province;
        }

        public async Task<Province> GetProvinceByID(int id)
        {
            return await _context.Provinces.SingleOrDefaultAsync(p => p.province_id == id);
        }
    }
}
