using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class IncomingEventUser
    {
        [NotMapped]
        public const string TableName = "incoming_event_user";

        public Guid Id { get; set; }
        public Guid IncomingEventId { get; set; }
        public Guid UserId { get; set; }
        public bool IsParticipating { get; set; }

        public User User { get; set; }
        public IncomingEvent IncomingEvent { get; set; }
    }
}
