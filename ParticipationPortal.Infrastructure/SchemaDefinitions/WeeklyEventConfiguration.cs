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
    public class WeeklyEventConfiguration : IEntityTypeConfiguration<WeeklyEvent>
    {
        public void Configure(EntityTypeBuilder<WeeklyEvent> builder)
        {
            builder.ToTable(WeeklyEvent.TableName, ParticipationPortalContext.DEFAULT_SCHEMA);
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(u => u.DayOfWeek)
                .HasColumnName("day_of_week")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(u => u.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
