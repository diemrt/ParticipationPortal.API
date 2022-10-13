using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class User
    {
        public string TabelName { get; } = "user";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime InsertDate { get; set; }

        public Role Role { get; set; }
        public IEnumerable<IncomingEvent> IncomingEvents { get; set; }
    }
}
