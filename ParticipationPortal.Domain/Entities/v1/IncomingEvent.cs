using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class IncomingEvent
    {
        public string TableName { get; } = "incoming_event";

        public Guid Id { get; set; }
        public Guid WeeklyEventId { get; set; }
        public DateTime ActualDate { get; set; }

        public WeeklyEvent WeeklyEvent { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
