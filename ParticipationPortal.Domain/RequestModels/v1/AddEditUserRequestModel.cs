using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.RequestModels.v1
{
    public class AddEditUserRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
