using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class WeeklyEvent
    {
        [NotMapped]
        public const string TableName = "weekly_event";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }

        public ICollection<IncomingEvent> IncomingEvents { get; set; }
    }
}
