using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class IncomingEventUser
    {
        public string TabelName { get; } = "incoming_event_user";

        public Guid Id { get; set; }
        public Guid IncomingEventId { get; set; }
        public Guid UserId { get; set; }
        public bool IsParticipating { get; set; }
    }
}
