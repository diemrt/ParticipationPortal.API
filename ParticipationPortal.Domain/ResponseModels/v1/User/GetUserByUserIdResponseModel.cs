using ParticipationPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.ResponseModels.v1.User
{
    public class GetUserByUserIdResponseModel : GenericResponseModel<UserByUserIdResponseModel>
    {

    }

    public class UserByUserIdResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public GenericItem Role { get; set; }
    }
}
