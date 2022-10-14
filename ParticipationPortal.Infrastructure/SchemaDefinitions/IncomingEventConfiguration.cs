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
    public class IncomingEventConfiguration : IEntityTypeConfiguration<IncomingEvent>
    {
        public void Configure(EntityTypeBuilder<IncomingEvent> builder)
        {
            builder.ToTable(IncomingEvent.TableName, ParticipationPortalContext.DEFAULT_SCHEMA);
            builder.HasKey(u => u.Id);

            builder.Property(u => u.ActualDate)
                .HasColumnName("actual_date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(u => u.WeeklyEventId)
                .HasColumnName("weekly_event_id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.HasOne(u => u.WeeklyEvent)
                .WithMany(c => c.IncomingEvents)
                .HasForeignKey(u => u.WeeklyEventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
