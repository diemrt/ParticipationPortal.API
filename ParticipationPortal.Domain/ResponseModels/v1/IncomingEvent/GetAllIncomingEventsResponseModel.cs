using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.ResponseModels.v1.IncomingEvent
{
    public class GetAllIncomingEventsResponseModel : GenericListResponseModel<AllIncomingEventsResponseModel>
    {
    }

    public class AllIncomingEventsResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<NeededRoleResponseModel> NeededRoles { get; set; }
        public IEnumerable<InvolvedUserResponseModel> InvolvedUsers { get; set; }
    }
}
