using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParticipationPortal.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Infrastructure.SchemaDefinitions
{
    public class WeeklyEventRoleConfiguration : IEntityTypeConfiguration<WeeklyEventRole>
    {
        public void Configure(EntityTypeBuilder<WeeklyEventRole> builder)
        {
            builder.ToTable(WeeklyEventRole.TableName, ParticipationPortalContext.DEFAULT_SCHEMA);
            builder.HasKey(u => u.Id);

            builder.Property(u => u.WeeklyEventId)
                .HasColumnName("weekly_event_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(u => u.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(u => u.Role)
                .WithMany(c => c.IncomingEventRoles)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.WeeklyEvent)
                .WithMany(c => c.WeeklyEventRoles)
                .HasForeignKey(u => u.WeeklyEventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
