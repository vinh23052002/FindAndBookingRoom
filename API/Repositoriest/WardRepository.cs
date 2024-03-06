﻿using API.Dtos.Ward;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositoriest
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
            var wards = await roomContext.Wards.ToListAsync();
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
            var ward = await roomContext.Wards.FirstOrDefaultAsync(x => x.ward_id == id);
            return _mapper.Map<WardResponse>(ward);
        }

        public async Task<List<WardResponse>> GetWardsByDistrictID(int id)
        {
            var wards = await roomContext.Wards.Where(x => x.district_id == id).ToListAsync();
            return _mapper.Map<List<WardResponse>>(wards);
        }

    }
}
