using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.RequestModels.v1.User
{
    public class AddUserRequestModel : AddEditUserRequestModel
    {
        public string FirebaseUserId { get; set; }
    }
}
