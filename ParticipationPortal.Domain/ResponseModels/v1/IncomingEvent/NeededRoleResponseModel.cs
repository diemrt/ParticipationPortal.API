using ParticipationPortal.Domain.Common;

namespace ParticipationPortal.Domain.ResponseModels.v1.IncomingEvent
{
    public class NeededRoleResponseModel
    {
        public Guid Id { get; set; }
        public GenericItem Role { get; set; }
        public bool IsCovered { get; set; }
    }
}