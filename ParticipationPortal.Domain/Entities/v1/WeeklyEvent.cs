using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class WeeklyEvent
    {
        public string TableName { get; } = "weekly_event";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
    }
}
