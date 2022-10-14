using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Entities.v1
{
    public class User
    {
        [NotMapped]
        public const string TableName = "user";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirebaseUserId { get; set; }
        public int RoleId { get; set; }
        public DateTime InsertDate { get; set; }

        public Role Role { get; set; }
        public ICollection<IncomingEventUser> IncomingEventUsers { get; set; }
    }
}
