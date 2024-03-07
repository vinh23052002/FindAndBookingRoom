﻿using API.Models;
using API.Repositoriest.GenericRepository;

namespace API.Repositoriest.role
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(RoomContext context) : base(context)
        {

        }
    }

}
