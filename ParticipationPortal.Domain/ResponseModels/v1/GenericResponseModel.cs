using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.ResponseModels.v1
{
    public class GenericResponseModel<T>
    {
        public T Data { get; set; }
    }
}
