using ParticipationPortal.Domain.RequestModels.v1.User;
using ParticipationPortal.Domain.ResponseModels.v1.User;
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
        Task<GetUserByUserIdResponseModel> GetByUserIdAsync(string userId);
    }
}
