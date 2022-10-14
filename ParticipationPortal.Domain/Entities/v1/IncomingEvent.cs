using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class IncomingEvent
    {
        [NotMapped]
        public const string TableName = "incoming_event";

        public Guid Id { get; set; }
        public Guid WeeklyEventId { get; set; }
        public DateTime ActualDate { get; set; }

        public WeeklyEvent WeeklyEvent { get; set; }
        public ICollection<IncomingEventRole> IncomingEventRoles { get; set; }
        public ICollection<IncomingEventUser> IncomingEventUsers { get; set; }
    }
}
