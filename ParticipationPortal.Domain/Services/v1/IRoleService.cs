using ParticipationPortal.Domain.ResponseModels.v1.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Services.v1
{
    public interface IRoleService
    {
        Task<GetAllRolesResponseModel> GetAllAsync();
    }
}
