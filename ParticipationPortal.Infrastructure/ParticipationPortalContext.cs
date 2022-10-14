using Microsoft.EntityFrameworkCore;
using ParticipationPortal.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Infrastructure
{
    public class ParticipationPortalContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";

        public ParticipationPortalContext(DbContextOptions<ParticipationPortalContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(builder);
        }

        public DbSet<IncomingEvent> IncomingEvents { get; set; }
        public DbSet<IncomingEventRole> IncomingEventRoles { get; set; }
        public DbSet<IncomingEventUser> IncomingEventUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WeeklyEvent> WeeklyEvents { get; set; }
    }
}
