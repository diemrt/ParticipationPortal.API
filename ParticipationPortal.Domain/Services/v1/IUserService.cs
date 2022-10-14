using ParticipationPortal.Domain.RequestModels.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Services.v1
{
    public interface IUserService
    {
        Task CreateAsync(string userId, AddUserRequestModel model);
    }
}
