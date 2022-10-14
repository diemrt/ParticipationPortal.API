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
    public class IncomingEventUserConfiguration : IEntityTypeConfiguration<IncomingEventUser>
    {
        public void Configure(EntityTypeBuilder<IncomingEventUser> builder)
        {
            builder.ToTable(IncomingEventUser.TableName, ParticipationPortalContext.DEFAULT_SCHEMA);
            builder.HasKey(u => u.Id);

            builder.Property(u => u.IncomingEventId)
                .HasColumnName("incoming_event_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(u => u.UserId)
                .HasColumnName("user_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(u => u.IsParticipating)
                .HasColumnName("is_participating")
                .HasColumnType("bit")
                .IsRequired();

            builder.HasOne(u => u.User)
                .WithMany(c => c.IncomingEventUsers)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.IncomingEvent)
                .WithMany(c => c.IncomingEventUsers)
                .HasForeignKey(u => u.IncomingEventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
