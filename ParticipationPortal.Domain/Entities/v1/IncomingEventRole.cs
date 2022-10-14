using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class IncomingEventRole
    {
        [NotMapped]
        public const string TableName = "incoming_event_role";

        public Guid Id { get; set; }
        public Guid IncomingEventId { get; set; }
        public int RoleId { get; set; }
        public bool IsCovered { get; set; }

        public IncomingEvent IncomingEvent { get; set; }
        public Role Role { get; set; }

    }
}
