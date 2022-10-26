using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.ResponseModels.v1
{
    public class GenericListResponseModel<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}
