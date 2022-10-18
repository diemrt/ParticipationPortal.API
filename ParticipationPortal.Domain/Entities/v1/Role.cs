using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class Role
    {
        [NotMapped]
        public const string TableName = "role";

        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<WeeklyEventRole> IncomingEventRoles { get; set; }
    }
}
