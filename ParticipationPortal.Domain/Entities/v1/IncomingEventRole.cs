using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class IncomingEventRole
    {
        public string TableName { get; } = "incoming_event_role";

        public Guid Id { get; set; }
        public Guid IncomingEventId { get; set; }
        public int RoleId { get; set; }
        public bool IsCovered { get; set; }

    }
}
