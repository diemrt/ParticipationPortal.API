using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.Repositories.v1;
using ParticipationPortal.Domain.ResponseModels.v1.Role;
using ParticipationPortal.Domain.Services.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Services.Application.v1
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            this._roleRepository = roleRepository;
            this._mapper = mapper;
        }
        public async Task<GetAllRolesResponseModel> GetAllAsync()
        {
            var result = new GetAllRolesResponseModel();

            IEnumerable<Role> roles = await _roleRepository.GetAllAsync();
            result.Data = _mapper.Map<IEnumerable<GenericItem>>(roles);
            return result;
        }
    }
}
