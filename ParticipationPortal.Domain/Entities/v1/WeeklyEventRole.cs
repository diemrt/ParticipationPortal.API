using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class WeeklyEventRole
    {
        [NotMapped]
        public const string TableName = "weekly_event_role";

        public Guid Id { get; set; }
        public Guid WeeklyEventId { get; set; }
        public int RoleId { get; set; }

        public WeeklyEvent WeeklyEvent { get; set; }
        public Role Role { get; set; }

    }
}
