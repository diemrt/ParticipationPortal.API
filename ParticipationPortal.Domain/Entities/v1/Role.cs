using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class Role
    {
        public string TableName { get; } = "role";

        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }

        public IEnumerable<IncomingEvent> IncomingEvents { get; set; }
    }
}
