using ParticipationPortal.Domain.RequestModels.v1;
using ParticipationPortal.Domain.Services.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Services.Application.v1
{
    public class UserService : IUserService
    {
        public Task CreateAsync(string userId, AddUserRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
