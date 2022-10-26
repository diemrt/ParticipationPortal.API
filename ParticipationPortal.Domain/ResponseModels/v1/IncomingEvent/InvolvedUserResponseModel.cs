using ParticipationPortal.Domain.Common;

namespace ParticipationPortal.Domain.ResponseModels.v1.IncomingEvent
{
    public class InvolvedUserResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GenericItem Role { get; set; }
        public bool IsParticipating { get; set; }
    }
}