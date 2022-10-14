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
    public class IncomingEventRoleConfiguration : IEntityTypeConfiguration<IncomingEventRole>
    {
        public void Configure(EntityTypeBuilder<IncomingEventRole> builder)
        {
            builder.ToTable(IncomingEventRole.TableName, ParticipationPortalContext.DEFAULT_SCHEMA);
            builder.HasKey(u => u.Id);

            builder.Property(u => u.IncomingEventId)
                .HasColumnName("incoming_event_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(u => u.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(u => u.IsCovered)
                .HasColumnName("is_covered")
                .HasColumnType("bit");

            builder.HasOne(u => u.Role)
                .WithMany(c => c.IncomingEventRoles)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.IncomingEvent)
                .WithMany(c => c.IncomingEventRoles)
                .HasForeignKey(u => u.IncomingEventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
